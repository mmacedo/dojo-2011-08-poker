using System;

namespace PokerEmCSharp
{
    public enum Rank
    {
        As = 1,
        Dois,
        Tres,
        Quatro,
        Cinco,
        Seis,
        Sete,
        Oito,
        Nove,
        Dez,
        Valete,
        Dama,
        Rei
    }

    public enum Naipe
    {
        Ouros,
        Copas,
        Paus,
        Espadas
    }

    public class Carta : IComparable
    {
        int IComparable.CompareTo(object outro)
        {
            if (outro is Carta)
            {
                var outraCarta = (Carta)outro;
                if (Rank < outraCarta.Rank)
                {
                    return -1;
                }
                if (Rank > outraCarta.Rank)
                {
                    return 1;
                }
                return 0;
            }
            throw new ArgumentException("Objeto não é uma Carta");
        }

        public Carta(Rank rank, Naipe suit)
        {
            Rank = rank;
            Naipe = suit;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Rank, Naipe);
        }

        public Rank Rank { get; private set; }

        public Naipe Naipe { get; private set; }
    }
}