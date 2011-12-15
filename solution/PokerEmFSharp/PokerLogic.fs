namespace PokerEmCSharp

open System

type Score =
    |HighCard
    |Pair
    |TwoPairs
    |ThreeOfAKind
    |Straight
    |Flush
    |FullHouse
    |FourOfAKind
    |StraightFlush
    |RoyalFlush

module PokerLogic =
    // active pattern to reuse a common case
    let (|AceHighStraight|_|) hand =
        match hand with
        |({ Rank = Rank.Ace },
          { Rank = Rank.Ten },
          { Rank = Rank.Jack },
          { Rank = Rank.Queen },
          { Rank = Rank.King })
           -> Some(AceHighStraight)
        |_ -> None

    (*
    * all cards are of the same suit
    *)
    let isFlush (c1, c2, c3, c4, c5) =
        c1.Suit = c2.Suit
     && c2.Suit = c3.Suit
     && c3.Suit = c4.Suit
     && c4.Suit = c5.Suit

    (*
    * the rank vary by 1, because it is ordered
    *)
    let isStraight hand =
        match hand with
        // special case: A is less then 10
        | AceHighStraight -> true
        | (c1, c2, c3, c4, c5) 
          when c1.Rank.ToInt() = c2.Rank.ToInt() - 1
            && c2.Rank.ToInt() = c3.Rank.ToInt() - 1
            && c3.Rank.ToInt() = c4.Rank.ToInt() - 1
            && c4.Rank.ToInt() = c5.Rank.ToInt() - 1
            -> true
        |_  -> false

    (*
    * must be flush and straight and have certain cards
    *)
    let isRoyalFlush hand =
        match hand with
        | AceHighStraight when isFlush hand -> true
        | _                                 -> false

    (*
    * must be straight and flush
    *)
    let isStraightFlush hand = isStraight hand && isFlush hand

    (*
    * whether the first four have the same rank
    * or the last four have the same rank
    *)
    let isFourOfAKind hand =
        match hand with
        // first four
        | (c1, c2, c3, c4, _) when c1.Rank = c2.Rank
                                && c2.Rank = c3.Rank
                                && c3.Rank = c4.Rank -> true
        // last four
        | (_, c2, c3, c4, c5) when c2.Rank = c3.Rank
                                && c3.Rank = c4.Rank
                                && c4.Rank = c5.Rank -> true
        | _                                          -> false

    (*
    * whether it is three of a kind followed by a pair
    * or a pair followed by three of a kind
    *)
    let isFullHouse hand =
        match hand with
        // two then three
        | (p1, p2, t1, t2, t3) when p1.Rank = p2.Rank
                                 && t1.Rank = t2.Rank
                                 && t2.Rank = t3.Rank -> true
        // three then two
        | (t1, t2, t3, p1, p2) when p1.Rank = p2.Rank
                                 && t1.Rank = t2.Rank
                                 && t2.Rank = t3.Rank -> true
        |_                                            -> false

    (*
    * whether the first three have the same rank
    * or the second three have the same rank
    * or the last three have the same rank
    *)
    let isThreeOfAKind hand =
        match hand with
        // first three
        | (c1, c2, c3, _, _) when c1.Rank = c2.Rank
                               && c2.Rank = c3.Rank -> true
        // second three
        | (_, c2, c3, c4, _) when c2.Rank = c3.Rank
                               && c3.Rank = c4.Rank -> true
        // last three
        | (_, _, c3, c4, c5) when c3.Rank = c4.Rank
                               && c4.Rank = c5.Rank -> true
        | _                                         -> false

    (*
    * whether the first four cards make two pairs
    * or the first two and last two cards are both pairs
    * or the last four make two pairs
    *)
    let isTwoPairs hand =
        match hand with
        // first four
        | (c1, c2, c3, c4, _) when c1.Rank = c2.Rank
                                && c3.Rank = c4.Rank -> true
        // first two and last two
        | (c1, c2, _, c4, c5) when c1.Rank = c2.Rank
                                && c4.Rank = c5.Rank -> true
        // last four
        | (_, c2, c3, c4, c5) when c2.Rank = c3.Rank
                                && c4.Rank = c5.Rank -> true
        | _                                          -> false

    (*
    * whether the 1st and 2nd cards have the same rank
    * or the 2nd and 3rd
    * or the 3rd and 4th
    * or the 4th and 5th
    *)
    let isPair hand =
        match hand with
        | (c1, c2, _, _, _) when c1.Rank = c2.Rank -> true
        | (_, c2, c3, _, _) when c2.Rank = c3.Rank -> true
        | (_, _, c3, c4, _) when c3.Rank = c4.Rank -> true
        | (_, _, _, c4, c5) when c4.Rank = c5.Rank -> true
        | _                                        -> false

    (*
    * assumes:
    * -> the hand is ordered
    * -> the hand does not have duplicated cards
    *)
    let GetScore hand =
        match hand with
        |(c1, c2, c3, c4, c5) when c1.Rank > c2.Rank
                                || c2.Rank > c3.Rank
                                || c3.Rank > c4.Rank
                                || c4.Rank > c5.Rank -> raise (new ArgumentException("Hand is not ordered."))
        |_ when isRoyalFlush hand    -> RoyalFlush
        |_ when isStraightFlush hand -> StraightFlush
        |_ when isFourOfAKind hand   -> FourOfAKind
        |_ when isFullHouse hand     -> FullHouse
        |_ when isFlush hand         -> Flush
        |_ when isStraight hand      -> Straight
        |_ when isThreeOfAKind hand  -> ThreeOfAKind
        |_ when isTwoPairs hand      -> TwoPairs
        |_ when isPair hand          -> Pair
        |_                           -> HighCard