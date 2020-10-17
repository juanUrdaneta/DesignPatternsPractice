using System;

namespace GOC
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard board = new GameBoard();
            board.PlayArea(PrimaryPlayer.Instance.Level);
            Console.ReadKey();
        }
    }
}
