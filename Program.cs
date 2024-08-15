using tabuleiro;
using xadrez_console;
using pecas_xadrez;

try
{
    PartidaDeXadrez partida = new PartidaDeXadrez();

    while (!partida.Terminada)
    {
        Console.Clear();
        Tela.ImprimirTabuleiro(partida.Tabuleiro);

        Console.WriteLine();
        Console.Write("Origem: ");
        Posicao origem = Tela.LerPosicaoXadrez().ConversorPosicao();

        bool[,] posicoesPossiveis = partida.Tabuleiro.Peca(origem).MovimentosPossiveis();

        Console.Clear();
        Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

        Console.WriteLine();
        Console.Write("Destino: ");
        Posicao destino = Tela.LerPosicaoXadrez().ConversorPosicao();

        partida.ExecutarMovimento(origem, destino);
    }

}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}

//PosicaoXadrez posicao = new PosicaoXadrez('c', 7);

//Console.WriteLine(posicao);
//Console.WriteLine(posicao.ConversorPosicao());