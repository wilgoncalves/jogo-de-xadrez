﻿using tabuleiro;

namespace pecas_xadrez
{
    internal class Cavalo : Peca
    {
        public Cavalo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
