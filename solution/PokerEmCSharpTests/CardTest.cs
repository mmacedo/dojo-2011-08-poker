using PokerEmCSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PokerEmCSharpTests
{
    [TestClass]
    public class CardTest
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

        #region Constructor and properties

        [TestMethod]
        public void ConstructorInitializeRank()
        {
            var card = new Card(Rank.Ace, Suit.Clubs);
            Assert.AreEqual(card.Rank, Rank.Ace);
        }

        [TestMethod]
        public void ConstructorInitializeSuit()
        {
            var card = new Card(Rank.Ace, Suit.Clubs);
            Assert.AreEqual(card.Suit, Suit.Clubs);
        }

        #endregion

        #region IComparable.CompareTo

        [TestMethod]
        public void CardsAreEqual()
        {
            IComparable card1 = new Card(Rank.Ace, Suit.Clubs);
            IComparable card2 = new Card(Rank.Ace, Suit.Diamonds);
            var result = card1.CompareTo(card2);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void CardIsGreaterThan()
        {
            IComparable card1 = new Card(Rank.Two, Suit.Clubs);
            IComparable card2 = new Card(Rank.Ace, Suit.Diamonds);
            var result = card1.CompareTo(card2);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void CardIsLessThan()
        {
            IComparable card1 = new Card(Rank.Ace, Suit.Clubs);
            IComparable card2 = new Card(Rank.Two, Suit.Diamonds);
            var result = card1.CompareTo(card2);
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToNullThrows()
        {
            IComparable card1 = new Card(Rank.Ace, Suit.Clubs);
            var result = card1.CompareTo(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareWithWrongTypeThrows()
        {
            IComparable card1 = new Card(Rank.Ace, Suit.Clubs);
            var result = card1.CompareTo(new object());
        }

        #endregion

        #region ToString

        [TestMethod]
        public void ReturnsAceOfClubsString()
        {
            var card = new Card(Rank.Ace, Suit.Clubs);
            var result = card.ToString();
            Assert.AreEqual(result, "A♣");
        }

        [TestMethod]
        public void ReturnTwoOfHeartsString()
        {
            var card = new Card(Rank.Two, Suit.Hearts);
            var result = card.ToString();
            Assert.AreEqual(result, "2♥");
        }

        [TestMethod]
        public void ReturnsTenOfDiamondsString()
        {
            var card = new Card(Rank.Ten, Suit.Diamonds);
            var result = card.ToString();
            Assert.AreEqual(result, "10♦");
        }

        [TestMethod]
        public void ReturnsKingOfSpadesString()
        {
            var card = new Card(Rank.Ten, Suit.Spades);
            var result = card.ToString();
            Assert.AreEqual(result, "10♠");
        }

        #endregion
    }
}
