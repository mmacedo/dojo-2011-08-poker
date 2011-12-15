using System;

namespace PokerEmCSharp
{
    public enum Rank
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public enum Suit
    {
        Diamonds,
        Hearts,
        Clubs,
        Spades
    }

    public class Card : IComparable
    {
        public Rank Rank { get; private set; }

        public Suit Suit { get; private set; }

        int IComparable.CompareTo(object other)
        {
            if (other is Card)
            {
                var otherCard = (Card)other;
                if (Rank < otherCard.Rank)
                {
                    return -1;
                }
                if (Rank > otherCard.Rank)
                {
                    return 1;
                }
                return 0;
            }
            throw new ArgumentException("Object is not a Card");
        }

        public static bool operator <(Card card1, Card card2)
        {
            return ((IComparable)card1).CompareTo(card2) < 0;
        }

        public static bool operator >(Card card1, Card card2)
        {
            return ((IComparable)card1).CompareTo(card2) > 0;
        }

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        private static string ConvertRankToString(Rank rank)
        {
            switch (rank)
            {
                case Rank.Ace: return "A";
                case Rank.Two: return "2";
                case Rank.Three: return "3";
                case Rank.Four: return "4";
                case Rank.Five: return "5";
                case Rank.Six: return "6";
                case Rank.Seven: return "7";
                case Rank.Eight: return "8";
                case Rank.Nine: return "9";
                case Rank.Ten: return "10";
                case Rank.Jack: return "J";
                case Rank.Queen: return "Q";
                case Rank.King: return "K";
                default: throw new ArgumentOutOfRangeException("Invalid rank!");
            }
        }

        private static string ConvertSuitToString(Suit suit)
        {
            switch (suit)
            {
                case Suit.Hearts: return "♥";
                case Suit.Diamonds: return "♦";
                case Suit.Clubs: return "♣";
                case Suit.Spades: return "♠";
                default: throw new ArgumentOutOfRangeException("Invalid suit!");
            }
        }

        public override string ToString()
        {
            return ConvertRankToString(Rank) + ConvertSuitToString(Suit);
        }
    }
}