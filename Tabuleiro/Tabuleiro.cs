namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,]? _pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            _pecas = new Peca[Linhas, Colunas];
        }

        public Peca Peca(int linha, int coluna)
        {
            return _pecas![linha, coluna];
        }

        public Peca Peca(Posicao posicao)
        {
            return _pecas![posicao.Linha, posicao.Coluna];
        }

        public bool ExistePeca(Posicao posicao)
        {
            ValidarPosicao(posicao);
            return Peca(posicao) != null;
        }

        public void ColocarPeca(Peca p, Posicao posicao)
        {
            if (ExistePeca(posicao))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }

            _pecas![posicao.Linha, posicao.Coluna] = p;
            p.Posicao = posicao;
        }

        public Peca RetirarPeca(Posicao posicao)
        {
            if (Peca(posicao) == null)
            {
                return null!;
            }
            Peca aux = Peca(posicao);
            aux.Posicao = null;
            _pecas![posicao.Linha, posicao.Coluna] = null!;
            return aux;
        }

        public bool PosicaoValida(Posicao posicao)
        {
            if (posicao.Linha < 0 || posicao.Linha >= Linhas 
                || posicao.Coluna < 0 || posicao.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao posicao)
        {
            if (!PosicaoValida(posicao))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}
