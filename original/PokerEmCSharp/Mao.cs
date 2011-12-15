using System;
using System.Linq;

namespace PokerEmCSharp
{
    public class Mao
    {
        private const int CartasNaMao = 5;

        private readonly Baralho _baralho;
        private readonly Carta[] _mao;

        public Mao(Baralho baralho)
        {
            _baralho = baralho;
            _mao = new Carta[CartasNaMao];
        }

        public void PescaCartas()
        {
            for (int i = 0; i < CartasNaMao; ++i)
            {
                _mao[i] = _baralho.PescaCarta();
            }

            Array.Sort(_mao);
        }

        public override string ToString()
        {
            var cartas = _mao.Select(carta => carta.ToString()).ToArray();
            return string.Join(", ", cartas);
        }

        public Carta this[int indice]
        {
            get
            {
                return _mao[indice];
            }
        }
    }
}