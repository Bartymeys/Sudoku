using System;

namespace Sudoku
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Proc proc = new Proc();
            Game game = new Game();
            proc.Create();
            proc.Show();
            while (true)
            {
                game.MoveCursor();      //постоянно ждёт ввода
            }
        }
    }
}
