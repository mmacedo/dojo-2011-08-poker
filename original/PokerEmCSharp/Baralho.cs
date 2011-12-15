using System;
using System.Linq;

namespace PokerEmCSharp
{
    public class Baralho
    {
        private const int CartasNoBaralho = 52;

        // lista de cartas
        private Carta[] _d;
        // contagem de cartas retiradas
        private int _cartasRetiradas;

        public Baralho()
        {
            Inicializa();
        }

        private void Inicializa()
        {
            _cartasRetiradas = 0;
            _d = (from Naipe n in Enum.GetValues(typeof (Naipe))
                  from Rank r in Enum.GetValues(typeof (Rank))
                  select new Carta(r, n)).ToArray();
        }

        public Carta PescaCarta()
        {
            return _d[_cartasRetiradas++];
        }

        /*
        * 10 é overkill, 8 seria o suficiente
        */
        public void Embaralha()
        {
            Embaralha(10);
        }

        /*
        * embaralha o baralho e reinicia a contagem de cartas
        */
        public void Embaralha(int vezes)
        {
            _cartasRetiradas = 0;
            for (int i = 0; i < vezes; ++i)
            {
                for (int j = 0; j < CartasNoBaralho; ++j)
                {
                    int idx = new Random().Next(CartasNoBaralho);
                    TrocaCartasDeLugar(j, idx);
                }
            }
        }

        private void TrocaCartasDeLugar(int carta1, int carta2)
        {
            var carta1Temp = _d[carta1];
            _d[carta1] = _d[carta2];
            _d[carta2] = carta1Temp;
        }
    }
}