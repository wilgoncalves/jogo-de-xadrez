﻿using tabuleiro;

namespace pecas_xadrez
{
    internal class Dama : Peca
    {
        public Dama(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "D";
        }
    }
}
