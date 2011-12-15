using PokerEmCSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PokerEmCSharpTests
{
    [TestClass]
    public class PokerLogicTest
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Create hands

        private static Hand CreateHandWithRoyalFlush()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(Rank.Ten, Suit.Clubs));
            hand.AddCard(new Card(Rank.Jack, Suit.Clubs));
            hand.AddCard(new Card(Rank.Queen, Suit.Clubs));
            hand.AddCard(new Card(Rank.King, Suit.Clubs));
            hand.AddCard(new Card(Rank.Ace, Suit.Clubs));
            return hand;
        }

        private static Hand CreateHandWithStraightFlush()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(Rank.Nine, Suit.Clubs));
            hand.AddCard(new Card(Rank.Ten, Suit.Clubs));
            hand.AddCard(new Card(Rank.Jack, Suit.Clubs));
            hand.AddCard(new Card(Rank.Queen, Suit.Clubs));
            hand.AddCard(new Card(Rank.King, Suit.Clubs));
            return hand;
        }

        private static Hand CreateHandWithFourOfAKind()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(Rank.Nine, Suit.Clubs));
            hand.AddCard(new Card(Rank.Nine, Suit.Hearts));
            hand.AddCard(new Card(Rank.Nine, Suit.Diamonds));
            hand.AddCard(new Card(Rank.Nine, Suit.Spades));
            hand.AddCard(new Card(Rank.King, Suit.Clubs));
            return hand;
        }

        private static Hand CreateHandWithFullHouse()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(Rank.Nine, Suit.Clubs));
            hand.AddCard(new Card(Rank.Nine, Suit.Hearts));
            hand.AddCard(new Card(Rank.Ten, Suit.Clubs));
            hand.AddCard(new Card(Rank.Ten, Suit.Hearts));
            hand.AddCard(new Card(Rank.Ten, Suit.Spades));
            return hand;
        }

        private static Hand CreateHandWithAceHighStraight()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(Rank.Ten, Suit.Hearts));
            hand.AddCard(new Card(Rank.Jack, Suit.Clubs));
            hand.AddCard(new Card(Rank.Queen, Suit.Clubs));
            hand.AddCard(new Card(Rank.King, Suit.Clubs));
            hand.AddCard(new Card(Rank.Ace, Suit.Clubs));
            return hand;
        }

        private static Hand CreateHandWithFlush()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(Rank.Ace, Suit.Clubs));
            hand.AddCard(new Card(Rank.Three, Suit.Clubs));
            hand.AddCard(new Card(Rank.Five, Suit.Clubs));
            hand.AddCard(new Card(Rank.Seven, Suit.Clubs));
            hand.AddCard(new Card(Rank.Nine, Suit.Clubs));
            return hand;
        }

        private static Hand CreateHandWithThreeOfAKind()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(Rank.Nine, Suit.Clubs));
            hand.AddCard(new Card(Rank.Nine, Suit.Hearts));
            hand.AddCard(new Card(Rank.Nine, Suit.Diamonds));
            hand.AddCard(new Card(Rank.Queen, Suit.Clubs));
            hand.AddCard(new Card(Rank.King, Suit.Clubs));
            return hand;
        }

        private static Hand CreateHandWithTwoPairs()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(Rank.Nine, Suit.Clubs));
            hand.AddCard(new Card(Rank.Nine, Suit.Hearts));
            hand.AddCard(new Card(Rank.Ten, Suit.Clubs));
            hand.AddCard(new Card(Rank.Ten, Suit.Hearts));
            hand.AddCard(new Card(Rank.King, Suit.Clubs));
            return hand;
        }

        private static Hand CreateHandWithOnePair()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(Rank.Nine, Suit.Clubs));
            hand.AddCard(new Card(Rank.Nine, Suit.Hearts));
            hand.AddCard(new Card(Rank.Jack, Suit.Clubs));
            hand.AddCard(new Card(Rank.Queen, Suit.Clubs));
            hand.AddCard(new Card(Rank.King, Suit.Clubs));
            return hand;
        }

        private static Hand CreateHandWithNoCombination()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(Rank.Ace, Suit.Clubs));
            hand.AddCard(new Card(Rank.Three, Suit.Hearts));
            hand.AddCard(new Card(Rank.Five, Suit.Diamonds));
            hand.AddCard(new Card(Rank.Seven, Suit.Spades));
            hand.AddCard(new Card(Rank.Nine, Suit.Clubs));
            return hand;
        }

        #endregion

        #region Consistency

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void HandWithoutExactlyFiveCardsThrows()
        {
            var hand = new Hand();
            PokerLogic.GetScore(hand);
        }

        #endregion

        #region IsRoyalFlush

        [TestMethod]
        public void HandWithRoyalFlushReturnsRoyalFlush()
        {
            var hand = CreateHandWithRoyalFlush();
            var result = PokerLogic.GetScore(hand);
            Assert.AreEqual(result, Score.RoyalFlush);
        }

        [TestMethod]
        public void HandWithAceHighStraightDoesNotReturnRoyalFlush()
        {
            var hand = CreateHandWithAceHighStraight();
            var result = PokerLogic.GetScore(hand);
            Assert.AreNotEqual(result, Score.RoyalFlush);
        }

        #endregion

        #region IsStraightFlush

        [TestMethod]
        public void HandWithStraightFlushReturnsStraightFlush()
        {
            var hand = CreateHandWithStraightFlush();
            var result = PokerLogic.GetScore(hand);
            Assert.AreEqual(result, Score.StraightFlush);
        }

        [TestMethod]
        public void HandWithStraightDoesNotReturnStraightFlush()
        {
            var hand = CreateHandWithAceHighStraight();
            var result = PokerLogic.GetScore(hand);
            Assert.AreNotEqual(result, Score.StraightFlush);
        }

        #endregion

        #region IsFourOfAKind

        [TestMethod]
        public void HandWithFourOfAKindReturnsFourOfAKind()
        {
            var hand = CreateHandWithFourOfAKind();
            var result = PokerLogic.GetScore(hand);
            Assert.AreEqual(result, Score.FourOfAKind);
        }

        #endregion

        #region IsFullHouse

        [TestMethod]
        public void HandWithFullHouseReturnsFullHouse()
        {
            var hand = CreateHandWithFullHouse();
            var result = PokerLogic.GetScore(hand);
            Assert.AreEqual(result, Score.FullHouse);
        }

        #endregion

        #region IsFlush

        [TestMethod]
        public void HandWithFlushReturnsFlush()
        {
            var hand = CreateHandWithFlush();
            var result = PokerLogic.GetScore(hand);
            Assert.AreEqual(result, Score.Flush);
        }

        #endregion

        #region IsStraight

        [TestMethod]
        public void HandWithStraightReturnsStraight()
        {
            var hand = CreateHandWithAceHighStraight();
            var result = PokerLogic.GetScore(hand);
            Assert.AreEqual(result, Score.Straight);
        }

        #endregion

        #region IsThreeOfAKind

        [TestMethod]
        public void HandWithThreeOfAKindReturnsThreeOfAKind()
        {
            var hand = CreateHandWithThreeOfAKind();
            var result = PokerLogic.GetScore(hand);
            Assert.AreEqual(result, Score.ThreeOfAKind);
        }

        #endregion

        #region IsTwoPairs

        [TestMethod]
        public void HandWithTwoPairsReturnsTwoPairs()
        {
            var hand = CreateHandWithTwoPairs();
            var result = PokerLogic.GetScore(hand);
            Assert.AreEqual(result, Score.TwoPair);
        }

        #endregion

        #region IsPair

        [TestMethod]
        public void HandWithOnePairReturnsPair()
        {
            var hand = CreateHandWithOnePair();
            var result = PokerLogic.GetScore(hand);
            Assert.AreEqual(result, Score.Pair);
        }

        #endregion

        #region IsHighCard

        [TestMethod]
        public void HandWithNoCombinationReturnsHighCard()
        {
            var hand = CreateHandWithNoCombination();
            var result = PokerLogic.GetScore(hand);
            Assert.AreEqual(result, Score.HighCard);
        }

        #endregion
    }
}
