namespace PokerEmFSharpTests.Tests

open PokerEmCSharp
open NUnit.Framework
open FsUnit

[<TestFixture>] 
type ``Given a module that calculates the score for a hand`` ()=
    let handWithRoyalFlush =
        ({ Rank = Ten ; Suit = Clubs },
         { Rank = Jack ; Suit = Clubs },
         { Rank = Queen ; Suit = Clubs },
         { Rank = King ; Suit = Clubs },
         { Rank = Ace ; Suit = Clubs })

    let handWithStraightFlush =
        ({ Rank = Nine ; Suit = Clubs },
         { Rank = Ten ; Suit = Clubs },
         { Rank = Jack ; Suit = Clubs },
         { Rank = Queen ; Suit = Clubs },
         { Rank = King ; Suit = Clubs })

    let handWithFourOfAKind =
        ({ Rank = Nine ; Suit = Clubs },
         { Rank = Nine ; Suit = Hearts },
         { Rank = Nine ; Suit = Diamonds },
         { Rank = Nine ; Suit = Spades },
         { Rank = King ; Suit = Clubs })

    let handWithFullHouse =
        ({ Rank = Nine ; Suit = Clubs },
         { Rank = Nine ; Suit = Hearts },
         { Rank = Ten ; Suit = Clubs },
         { Rank = Ten ; Suit = Hearts },
         { Rank = Ten ; Suit = Spades })

    let handWithAceHighStraight =
        ({ Rank = Ten ; Suit = Hearts },
         { Rank = Jack ; Suit = Clubs },
         { Rank = Queen ; Suit = Clubs },
         { Rank = King ; Suit = Clubs },
         { Rank = Ace ; Suit = Clubs })

    let handWithFlush =
        ({ Rank = Ace ; Suit = Clubs },
         { Rank = Three ; Suit = Clubs },
         { Rank = Five ; Suit = Clubs },
         { Rank = Seven ; Suit = Clubs },
         { Rank = Nine ; Suit = Clubs })

    let handWithThreeOfAKind =
        ({ Rank = Nine ; Suit = Clubs },
         { Rank = Nine ; Suit = Hearts },
         { Rank = Nine ; Suit = Diamonds },
         { Rank = Queen ; Suit = Clubs },
         { Rank = King ; Suit = Clubs })

    let handWithTwoPairs =
        ({ Rank = Nine ; Suit = Clubs },
         { Rank = Nine ; Suit = Hearts },
         { Rank = Ten ; Suit = Clubs },
         { Rank = Ten ; Suit = Hearts },
         { Rank = King ; Suit = Clubs })

    let handWithPair =
        ({ Rank = Nine ; Suit = Clubs },
         { Rank = Nine ; Suit = Hearts },
         { Rank = Jack ; Suit = Clubs },
         { Rank = Queen ; Suit = Clubs },
         { Rank = King ; Suit = Clubs })

    let handWithNoCombination =
        ({ Rank = Ace ; Suit = Clubs },
         { Rank = Three ; Suit = Hearts },
         { Rank = Five ; Suit = Diamonds },
         { Rank = Seven ; Suit = Spades },
         { Rank = Nine ; Suit = Clubs })

    let sortTuple5 (a, b, c, d, e) =
        let xs = [ a; b; c; d; e ] |> List.sortBy (fun x -> x.Rank)
        (xs.[0], xs.[1], xs.[2], xs.[3], xs.[4])

    [<Test>] member test.
     ``when score is calculated for a hand with a royal flush returns RoyalFlush.`` ()=
            PokerEmCSharp.PokerLogic.GetScore (sortTuple5 handWithRoyalFlush) |> should equal RoyalFlush

    [<Test>] member test.
     ``when score is calculated for a hand with a ace-high straight do not return RoyalFlush.`` ()=
            PokerEmCSharp.PokerLogic.GetScore (sortTuple5 handWithAceHighStraight) |> should not (equal RoyalFlush)

    [<Test>] member test.
     ``when score is calculated for a hand with a straight flush returns StraightFlush.`` ()=
            PokerEmCSharp.PokerLogic.GetScore (sortTuple5 handWithStraightFlush) |> should equal StraightFlush

    [<Test>] member test.
     ``when score is calculated for a hand with a straight do not return StraightFlush.`` ()=
            PokerEmCSharp.PokerLogic.GetScore (sortTuple5 handWithAceHighStraight) |> should not (equal StraightFlush)

    [<Test>] member test.
     ``when score is calculated for a hand with four of a kind returns FourOfAKind.`` ()=
            PokerEmCSharp.PokerLogic.GetScore (sortTuple5 handWithFourOfAKind) |> should equal FourOfAKind

    [<Test>] member test.
     ``when score is calculated for a hand with a full house returns FullHouse.`` ()=
            PokerEmCSharp.PokerLogic.GetScore (sortTuple5 handWithFullHouse) |> should equal FullHouse

    [<Test>] member test.
     ``when score is calculated for a hand with a flush returns Flush.`` ()=
            PokerEmCSharp.PokerLogic.GetScore (sortTuple5 handWithFlush) |> should equal Flush

    [<Test>] member test.
     ``when score is calculated for a hand with a straight returns Straight.`` ()=
            PokerEmCSharp.PokerLogic.GetScore (sortTuple5 handWithAceHighStraight) |> should equal Straight

    [<Test>] member test.
     ``when score is calculated for a hand with three of a kind returns ThreeOfAKind.`` ()=
            PokerEmCSharp.PokerLogic.GetScore (sortTuple5 handWithThreeOfAKind) |> should equal ThreeOfAKind

    [<Test>] member test.
     ``when score is calculated for a hand with two pairs returns TwoPairs.`` ()=
            PokerEmCSharp.PokerLogic.GetScore (sortTuple5 handWithTwoPairs) |> should equal TwoPairs

    [<Test>] member test.
     ``when score is calculated for a hand with one par returns Pair.`` ()=
            PokerEmCSharp.PokerLogic.GetScore (sortTuple5 handWithPair) |> should equal Pair

    [<Test>] member test.
     ``when score is calculated for a hand without combinations returns HighCard.`` ()=
            PokerEmCSharp.PokerLogic.GetScore (sortTuple5 handWithNoCombination) |> should equal HighCard