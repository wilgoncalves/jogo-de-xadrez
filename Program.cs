using tabuleiro;
using xadrez_console;
using pecas_xadrez;

try
{
    PartidaDeXadrez partida = new PartidaDeXadrez();

    while (!partida.Terminada)
    {
        try
        {
            Console.Clear();
            Tela.ImprimirPartida(partida);

            Console.WriteLine();
            Console.Write("Origem: ");
            Posicao origem = Tela.LerPosicaoXadrez().ConversorPosicao();
            partida.ValidarPosicaoDeOrigem(origem);

            bool[,] posicoesPossiveis = partida.Tabuleiro.Peca(origem).MovimentosPossiveis();

            Console.Clear();
            Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

            Console.WriteLine();
            Console.Write("Destino: ");
            Posicao destino = Tela.LerPosicaoXadrez().ConversorPosicao();
            partida.ValidarPosicaoDeDestino(origem, destino);

            partida.RealizarJogada(origem, destino);
        }
        catch (TabuleiroException e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }

    }

}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}

//PosicaoXadrez posicao = new PosicaoXadrez('c', 7);

//Console.WriteLine(posicao);
//Console.WriteLine(posicao.ConversorPosicao());