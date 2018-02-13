using System;


namespace Sudoku
{
    class Game
    {
        Proc proc = new Proc();
        public static int xCursor = 0;
        public static int yCursor = 0;
        public static int i = 0;
        public static int j = 0;

        public void PrintCursor(int x, int y)
        {
            if (0 <= xCursor + x &&                 //выход за границы поля
                0 <= yCursor + y &&
                11 > yCursor + y &&
                21 > xCursor + x) 
            {
                if ((yCursor + y) % 4 == 3)
                    yCursor = yCursor + 2 * y;      //2 * чтобы перескакивать разделение полей
                else if((xCursor + 2 * x) == 6 || (xCursor + 2 * x) == 14)
                    xCursor = xCursor + 4 * x;      //по вертикали всегда есть пробелы, между блоками два
                else
                {
                    xCursor = xCursor + 2 * x;
                    yCursor = yCursor + y;
                }
                j += x;
                i += y;
            }
                proc.Show();                                    //отрисовка заново
                Console.SetCursorPosition(xCursor, yCursor);
        }

        public void MoveCursor()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();         //ожидание ввода
            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:      PrintCursor(-1,  0);    break;
                case ConsoleKey.RightArrow:     PrintCursor( 1,  0);    break;
                case ConsoleKey.UpArrow:        PrintCursor( 0, -1);    break;
                case ConsoleKey.DownArrow:      PrintCursor( 0,  1);    break;
                case ConsoleKey.NumPad1:        proc.Change(i, j, 1);   break;
                case ConsoleKey.NumPad2:        proc.Change(i, j, 2);   break;
                case ConsoleKey.NumPad3:        proc.Change(i, j, 3);   break;
                case ConsoleKey.NumPad4:        proc.Change(i, j, 4);   break;
                case ConsoleKey.NumPad5:        proc.Change(i, j, 5);   break;
                case ConsoleKey.NumPad6:        proc.Change(i, j, 6);   break;
                case ConsoleKey.NumPad7:        proc.Change(i, j, 7);   break;
                case ConsoleKey.NumPad8:        proc.Change(i, j, 8);   break;
                case ConsoleKey.NumPad9:        proc.Change(i, j, 9);   break;
                case ConsoleKey.D1:             proc.Change(i, j, 1);   break;
                case ConsoleKey.D2:             proc.Change(i, j, 2);   break;
                case ConsoleKey.D3:             proc.Change(i, j, 3);   break;
                case ConsoleKey.D4:             proc.Change(i, j, 4);   break;
                case ConsoleKey.D5:             proc.Change(i, j, 5);   break;
                case ConsoleKey.D6:             proc.Change(i, j, 6);   break;
                case ConsoleKey.D7:             proc.Change(i, j, 7);   break;
                case ConsoleKey.D8:             proc.Change(i, j, 8);   break;
                case ConsoleKey.D9:             proc.Change(i, j, 9);   break;
            }
        }
    }
}
