using PokerEmCSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PokerEmCSharpTests
{
    [TestClass]
    public class HandTest
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

        #region Constructor

        [TestMethod]
        public void ConstructorInitializesEmptyHand()
        {
            Hand hand = new Hand();
            Assert.AreEqual(hand.CardsCount, 0);
        }

        #endregion

        #region AddCard

        [TestMethod()]
        public void AddsOneCardHaveOneCardInTheHand()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Rank.Ace, Suit.Clubs));
            Assert.AreEqual(hand.CardsCount, 1);
        }

        [TestMethod()]
        public void AddsFiveCardsHaveFiveCardsInTheHand()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Rank.Ace, Suit.Clubs));
            hand.AddCard(new Card(Rank.Two, Suit.Clubs));
            hand.AddCard(new Card(Rank.Three, Suit.Clubs));
            hand.AddCard(new Card(Rank.Four, Suit.Clubs));
            hand.AddCard(new Card(Rank.Five, Suit.Clubs));
            Assert.AreEqual(hand.CardsCount, 5);
        }

        #endregion

        #region ToString

        [TestMethod]
        public void HaveOneCardReturnsCardAsString()
        {
            var card = new Card(Rank.Ace, Suit.Clubs);

            var hand = new Hand();
            hand.AddCard(card);
            Assert.AreEqual(hand.ToString(), card.ToString());
        }

        [TestMethod]
        public void HaveTwoCardsReturnsTwoCommaSeparatedCardsInAscendingOrderAsString()
        {
            var card1 = new Card(Rank.Three, Suit.Clubs);
            var card2 = new Card(Rank.Two, Suit.Clubs);

            var hand = new Hand();
            hand.AddCard(card1);
            hand.AddCard(card2);
            Assert.AreEqual(hand.ToString(), card2.ToString() + ", " + card1.ToString());
        }

        #endregion

        #region Indexador

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexerFailsWhenHandIsEmpty()
        {
            var hand = new Hand();
            var card = hand[0];
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexerFailsWhenPassedIndexLargerThanOrEqualCountOfCardsAtHand()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Rank.Ace, Suit.Clubs));
            var card = hand[1];
        }

        [TestMethod]
        public void IndexerReturnsOnZeroBasedIndex()
        {
            var card = new Card(Rank.Ace, Suit.Clubs);
            var hand = new Hand();
            hand.AddCard(card);
            Assert.AreEqual(card, hand[0]);
        }

        [TestMethod]
        public void IndexerReturnsCardsInAscendingOrder()
        {
            var card1 = new Card(Rank.Three, Suit.Clubs);
            var card2 = new Card(Rank.Two, Suit.Clubs);

            var hand = new Hand();
            hand.AddCard(card1);
            hand.AddCard(card2);
            Assert.AreEqual(card2, hand[0]);
        }

        [TestMethod]
        public void IndexerReturnsCardsByIndex()
        {
            var higherCardAdded = new Card(Rank.King, Suit.Clubs);

            var hand = new Hand();
            hand.AddCard(higherCardAdded);
            hand.AddCard(new Card(Rank.Queen, Suit.Clubs));
            hand.AddCard(new Card(Rank.Jack, Suit.Clubs));
            Assert.AreEqual(higherCardAdded, hand[2]);
        }

        #endregion
    }
}
