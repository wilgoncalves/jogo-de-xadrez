﻿using tabuleiro;

namespace pecas_xadrez
{
    internal class Peao : Peca
    {
        private PartidaDeXadrez _partidaDeXadrez;

        public Peao(Cor cor, Tabuleiro tabuleiro, PartidaDeXadrez partidaDeXadrez) : base(cor, tabuleiro)
        {
            _partidaDeXadrez = partidaDeXadrez;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExisteInimigo(Posicao posicao)
        {
            Peca peca = Tabuleiro!.Peca(posicao);
            return peca != null && peca.Cor != Cor;
        }

        private bool NaoExisteInimigo(Posicao posicao)
        {
            return Tabuleiro!.Peca(posicao) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro!.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(0, 0);

            if (Cor == Cor.Branca)
            {
                posicao.DefinirValores(Posicao!.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicao) && NaoExisteInimigo(posicao))
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.DefinirValores(Posicao!.Linha - 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicao) && NaoExisteInimigo(posicao) && QteMovimentos == 0)
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.DefinirValores(Posicao!.Linha - 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(posicao) && ExisteInimigo(posicao))
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.DefinirValores(Posicao!.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(posicao) && ExisteInimigo(posicao))
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                // #jogadaespecial en passant
                if (Posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) 
                        && Tabuleiro.Peca(esquerda) == _partidaDeXadrez.VulneravelEnPassant)
                    {
                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita)
                        && Tabuleiro.Peca(direita) == _partidaDeXadrez.VulneravelEnPassant)
                    {
                        mat[direita.Linha - 1, direita.Coluna] = true;
                    }
                }
            }
            else
            {
                posicao.DefinirValores(Posicao!.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicao) && NaoExisteInimigo(posicao))
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.DefinirValores(Posicao!.Linha + 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicao) && NaoExisteInimigo(posicao) && QteMovimentos == 0)
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.DefinirValores(Posicao!.Linha + 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(posicao) && ExisteInimigo(posicao))
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.DefinirValores(Posicao!.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(posicao) && ExisteInimigo(posicao))
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                // #jogadaespecial en passant
                if (Posicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda)
                        && Tabuleiro.Peca(esquerda) == _partidaDeXadrez.VulneravelEnPassant)
                    {
                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita)
                        && Tabuleiro.Peca(direita) == _partidaDeXadrez.VulneravelEnPassant)
                    {
                        mat[direita.Linha + 1, direita.Coluna] = true;
                    }
                }
            }

            return mat;
        }
    }
}
