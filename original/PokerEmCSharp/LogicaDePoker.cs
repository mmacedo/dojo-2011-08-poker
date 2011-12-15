namespace PokerEmCSharp
{
    public enum Combinacao
    {
        Nenhuma,
        Par,
        DoisPares,
        Trinca,
        Straight,
        Flush,
        FullHouse,
        Quadra,
        StraightFlush,
        RoyalFlush
    }

    public static class LogicaDePoker
    {
        /*
        * deve ser flush e straight e ter certas cartas
        */
        private static bool EhRoyalFlush(Mao h)
        {
            if (EhStraight(h) && EhFlush(h) &&
                h[0].Rank == Rank.As &&
                h[1].Rank == Rank.Dez &&
                h[2].Rank == Rank.Valete &&
                h[3].Rank == Rank.Dama &&
                h[4].Rank == Rank.Rei)
            {
                return true;
            }
            return false;
        }

        /*
        * é straight e flush
        */
        private static bool EhStraightFlush(Mao h)
        {
            if (EhStraight(h) && EhFlush(h))
            {
                return true;
            }
            return false;
        }

        /*
        * ou as quatro primeiras tem o mesmo rank
        * ou as quatro últimas tem o mesmo rank
        */
        private static bool EhQuadra(Mao h)
        {
            // quatro primeiras
            if (h[0].Rank == h[1].Rank &&
                h[1].Rank == h[2].Rank &&
                h[2].Rank == h[3].Rank)
            {
                return true;
            }
            // quatro últimas
            if (h[1].Rank == h[2].Rank &&
                h[2].Rank == h[3].Rank &&
                h[3].Rank == h[4].Rank)
            {
                return true;
            }
            return false;
        }

        /*
        * ou uma trinca e um par
        * ou um par e uma trinca
        */
        private static bool EhFullHouse(Mao h)
        {
            // par e trinca
            if (h[0].Rank == h[1].Rank &&
                h[2].Rank == h[3].Rank &&
                h[3].Rank == h[4].Rank)
            {
                return true;
            }
            // trinca e par
            if (h[0].Rank == h[1].Rank &&
                h[1].Rank == h[2].Rank &&
                h[3].Rank == h[4].Rank)
            {
                return true;
            }
            return false;
        }

        /*
        * todas as cartas são do mesmo naipe
        */
        private static bool EhFlush(Mao h)
        {
            if (h[0].Naipe == h[1].Naipe &&
                h[1].Naipe == h[2].Naipe &&
                h[2].Naipe == h[3].Naipe &&
                h[3].Naipe == h[4].Naipe)
            {
                return true;
            }
            return false;
        }

        /*
        * confere que o rank difere em 1
        * isso é possível porque assumimos
        * que está ordernado
        */
        private static bool EhStraight(Mao h)
        {
            if (h[0].Rank == h[1].Rank - 1 &&
                h[1].Rank == h[2].Rank - 1 &&
                h[2].Rank == h[3].Rank - 1 &&
                h[3].Rank == h[4].Rank - 1)
            {
                return true;
            }
            // caso special porque Az é menor que dez
            if (h[1].Rank == Rank.Dez &&
                h[2].Rank == Rank.Valete &&
                h[3].Rank == Rank.Dama &&
                h[4].Rank == Rank.Rei &&
                h[0].Rank == Rank.As)
            {
                return true;
            }
            return false;
        }

        /*
        * ou as três primeiras tem mesmo rank
        * ou as três do meio tem mesmo rank
        * ou as três últimas tem mesmo rank
        */
        private static bool EhTrinca(Mao h)
        {
            // três primeiras
            if (h[0].Rank == h[1].Rank &&
                h[1].Rank == h[2].Rank)
            {
                return true;
            }
            // três do meio
            if (h[1].Rank == h[2].Rank &&
                h[2].Rank == h[3].Rank)
            {
                return true;
            }
            // três últimas
            if (h[2].Rank == h[3].Rank &&
                h[3].Rank == h[4].Rank)
            {
                return true;
            }
            return false;
        }

        /*
        * ou dois pares no início
        * ou dois pares separados pela carta do meio
        * ou dois pares no final
        */
        private static bool EhDoisPares(Mao h)
        {
            // dois pares no início
            if (h[0].Rank == h[1].Rank &&
                h[2].Rank == h[3].Rank)
            {
                return true;
            }
            // dois pares separados pela carta do meio
            if (h[0].Rank == h[1].Rank &&
                h[3].Rank == h[4].Rank)
            {
                return true;
            }
            // dois pares no final
            if (h[1].Rank == h[2].Rank &&
                h[3].Rank == h[4].Rank)
            {
                return true;
            }
            return false;
        }

        /*
        * ou a 1a carta igual a 2a carta
        * ou a 2a carta igual a 3a carta
        * ou a 3a carta igual a 4a carta
        * ou a 4a carta igual a 5a carta
        */
        private static bool EhPar(Mao h)
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

        /*
        * assume:
        * -> a mão deve estar ordenada
        * -> as cartas não podem repetir
        */
        public static Combinacao CalculaScore(Mao h)
        {
            if (EhRoyalFlush(h))
            {
                return Combinacao.RoyalFlush;
            }
            if (EhStraightFlush(h))
            {
                return Combinacao.StraightFlush;
            }
            if (EhQuadra(h))
            {
                return Combinacao.Quadra;
            }
            if (EhFullHouse(h))
            {
                return Combinacao.FullHouse;
            }
            if (EhFlush(h))
            {
                return Combinacao.Flush;
            }
            if (EhStraight(h))
            {
                return Combinacao.Straight;
            }
            if (EhTrinca(h))
            {
                return Combinacao.Trinca;
            }
            if (EhDoisPares(h))
            {
                return Combinacao.DoisPares;
            }
            if (EhPar(h))
            {
                return Combinacao.Par;
            }
            return Combinacao.Nenhuma;
        }
    }
}