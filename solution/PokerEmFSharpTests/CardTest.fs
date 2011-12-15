namespace PokerEmFSharpTests.Tests

open PokerEmCSharp
open NUnit.Framework
open FsUnit

[<TestFixture>] 
type ``Given a two of Hearts`` ()=
    let card = { Rank = Two; Suit = Hearts }

    [<Test>] member test.
     ``when ToString is called returns "2♥".`` ()=
            card.ToString() |> should equal "2♥"

[<TestFixture>] 
type ``Given a ten of Spades`` ()=
    let card = { Rank = Ten; Suit = Spades }

    [<Test>] member test.
     ``when ToString is called returns "10♠".`` ()=
            card.ToString() |> should equal "10♠"

[<TestFixture>]
type ``Given an eight of Diamonds`` ()=
    let card = { Rank = Eight; Suit = Diamonds }

    [<Test>] member test.
     ``when ToString is called returns "8♦".`` ()=
            card.ToString() |> should equal "8♦"

[<TestFixture>] 
type ``Given an ace of Clubs`` ()=
    let card = { Rank = Ace; Suit = Clubs }

    [<Test>] member test.
     ``when ToString is called returns "A♣".`` ()=
            card.ToString() |> should equal "A♣"