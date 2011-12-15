using System;
namespace PokerEmCSharp
{
    public enum Score
    {
        HighCard,
        Pair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    }

    public static class PokerLogic
    {
        /*
        * assumes:
        * -> the hand has five cards
        * -> the hand is ordered
        * -> the hand does not have duplicated cards
        */
        public static Score GetScore(Hand h)
        {
            if (h.CardsCount != 5) throw new ArgumentException("Hand must have five cards.");
            if (h[0] > h[1] || h[1] > h[2] || h[2] > h[3] || h[3] > h[4]) throw new ArgumentException("Hand must be ordered.");

            if (IsRoyalFlush(h))
            {
                return Score.RoyalFlush;
            }
            if (IsStraightFlush(h))
            {
                return Score.StraightFlush;
            }
            if (IsFourOfAKind(h))
            {
                return Score.FourOfAKind;
            }
            if (IsFullHouse(h))
            {
                return Score.FullHouse;
            }
            if (IsFlush(h))
            {
                return Score.Flush;
            }
            if (IsStraight(h))
            {
                return Score.Straight;
            }
            if (IsThreeOfAKind(h))
            {
                return Score.ThreeOfAKind;
            }
            if (IsTwoPairs(h))
            {
                return Score.TwoPair;
            }
            if (IsPair(h))
            {
                return Score.Pair;
            }
            return Score.HighCard;
        }

        /*
        * must be flush and straight and have certain cards
        */
        private static bool IsRoyalFlush(Hand h)
        {
            if (IsFlush(h) &&
                h[0].Rank == Rank.Ace &&
                h[1].Rank == Rank.Ten &&
                h[2].Rank == Rank.Jack &&
                h[3].Rank == Rank.Queen &&
                h[4].Rank == Rank.King)
            {
                return true;
            }
            return false;
        }

        /*
        * must be straight and flush
        */
        private static bool IsStraightFlush(Hand h)
        {
            if (IsStraight(h) && IsFlush(h))
            {
                return true;
            }
            return false;
        }

        /*
        * whether the first four have the same rank
        * or the last four have the same rank
        */
        private static bool IsFourOfAKind(Hand h)
        {
            // first four
            if (h[0].Rank == h[1].Rank &&
                h[1].Rank == h[2].Rank &&
                h[2].Rank == h[3].Rank)
            {
                return true;
            }
            // last four
            if (h[1].Rank == h[2].Rank &&
                h[2].Rank == h[3].Rank &&
                h[3].Rank == h[4].Rank)
            {
                return true;
            }
            return false;
        }

        /*
        * whether it is three of a kind followed by a pair
        * or a pair followed by three of a kind
        */
        private static bool IsFullHouse(Hand h)
        {
            // two then three
            if (h[0].Rank == h[1].Rank &&
                h[2].Rank == h[3].Rank &&
                h[3].Rank == h[4].Rank)
            {
                return true;
            }
            // three then two
            if (h[0].Rank == h[1].Rank &&
                h[1].Rank == h[2].Rank &&
                h[3].Rank == h[4].Rank)
            {
                return true;
            }
            return false;
        }

        /*
        * all cards are of the same suit
        */
        private static bool IsFlush(Hand h)
        {
            if (h[0].Suit == h[1].Suit &&
                h[1].Suit == h[2].Suit &&
                h[2].Suit == h[3].Suit &&
                h[3].Suit == h[4].Suit)
            {
                return true;
            }
            return false;
        }

        /*
        * the rank vary by 1, because it is ordered
        */
        private static bool IsStraight(Hand h)
        {
            if (h[0].Rank == h[1].Rank - 1 &&
                h[1].Rank == h[2].Rank - 1 &&
                h[2].Rank == h[3].Rank - 1 &&
                h[3].Rank == h[4].Rank - 1)
            {
                return true;
            }
            // special case: A is less then 10
            if (h[1].Rank == Rank.Ten &&
                h[2].Rank == Rank.Jack &&
                h[3].Rank == Rank.Queen &&
                h[4].Rank == Rank.King &&
                h[0].Rank == Rank.Ace)
            {
                return true;
            }
            return false;
        }

        /*
        * whether the first three have the same rank
        * or the second three have the same rank
        * or the last three have the same rank
        */
        private static bool IsThreeOfAKind(Hand h)
        {
            // first three
            if (h[0].Rank == h[1].Rank &&
                h[1].Rank == h[2].Rank)
            {
                return true;
            }
            // second three
            if (h[1].Rank == h[2].Rank &&
                h[2].Rank == h[3].Rank)
            {
                return true;
            }
            // last three
            if (h[2].Rank == h[3].Rank &&
                h[3].Rank == h[4].Rank)
            {
                return true;
            }
            return false;
        }

        /*
        * whether the first four cards make two pairs
        * or the first two and last two cards are both pairs
        * or the last four make two pairs
        */
        private static bool IsTwoPairs(Hand h)
        {
            // first four
            if (h[0].Rank == h[1].Rank &&
                h[2].Rank == h[3].Rank)
            {
                return true;
            }
            // first two and last two
            if (h[0].Rank == h[1].Rank &&
                h[3].Rank == h[4].Rank)
            {
                return true;
            }
            // last four
            if (h[1].Rank == h[2].Rank &&
                h[3].Rank == h[4].Rank)
            {
                return true;
            }
            return false;
        }

        /*
        * whether the 1st and 2nd cards have the same rank
        * or the 2nd and 3rd
        * or the 3rd and 4th
        * or the 4th and 5th
        */
        private static bool IsPair(Hand h)
        {
            if (h[0].Rank == h[1].Rank)
            {
                return true;
            }
            if (h[1].Rank == h[2].Rank)
            {
                return true;
            }
            if (h[2].Rank == h[3].Rank)
            {
                return true;
            }
            if (h[3].Rank == h[4].Rank)
            {
                return true;
            }
            return false;
        }
    }
}