using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerEmCSharp
{
    public class Hand
    {
        private readonly List<Card> _cards;

        public Hand()
        {
            _cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            _cards.Add(card);
            _cards.Sort();
        }

        public Card this[int indice]
        {
            get
            {
                if (indice < 0) throw new ArgumentOutOfRangeException("Indice não pode ser negativo.");
                if (indice >= CardsCount) throw new ArgumentOutOfRangeException("Indice deve ser menor do que o número de cards na mão.");

                return _cards[indice];
            }
        }

        public int CardsCount
        {
            get { return _cards.Count; }
        }

        public override string ToString()
        {
            var cards = (from card in _cards orderby card.Rank select card.ToString()).ToArray();
            return string.Join(", ", cards);
        }
    }
}