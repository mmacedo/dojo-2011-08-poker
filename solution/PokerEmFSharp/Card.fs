namespace PokerEmCSharp

type Rank =
    | Ace
    | Two
    | Three
    | Four
    | Five
    | Six
    | Seven
    | Eight
    | Nine
    | Ten
    | Jack
    | Queen
    | King
    override rank.ToString() =
        match rank with
        | Rank.Ace    -> "A"
        | Rank.Two    -> "2"
        | Rank.Three  -> "3"
        | Rank.Four   -> "4"
        | Rank.Five   -> "5"
        | Rank.Six    -> "6"
        | Rank.Seven  -> "7"
        | Rank.Eight  -> "8"
        | Rank.Nine   -> "9"
        | Rank.Ten    -> "10"
        | Rank.Jack   -> "J"
        | Rank.Queen  -> "Q"
        | Rank.King   -> "K"
    member rank.ToInt() =
        match rank with
        | Rank.Ace    -> 1
        | Rank.Two    -> 2
        | Rank.Three  -> 3
        | Rank.Four   -> 4
        | Rank.Five   -> 5
        | Rank.Six    -> 6
        | Rank.Seven  -> 7
        | Rank.Eight  -> 8
        | Rank.Nine   -> 9
        | Rank.Ten    -> 10
        | Rank.Jack   -> 11
        | Rank.Queen  -> 12
        | Rank.King   -> 13

type Suit =
    | Clubs
    | Diamonds
    | Hearts
    | Spades
    override suit.ToString() =
        match suit with
        | Clubs     -> "♣"
        | Diamonds  -> "♦"
        | Hearts    -> "♥"
        | Spades    -> "♠"

type Card =
    { Rank:Rank; Suit:Suit }
    override card.ToString() = card.Rank.ToString() + card.Suit.ToString()