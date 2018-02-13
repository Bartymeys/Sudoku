using System;

namespace Sudoku
{
    
    class Proc
    {
        static Random random = new Random();
        public static int[,] mas = new int[9, 9];      //массив значений всего поля

        public void Create()
        {

            int emp = 0;

            for (int i = 0; i < 9; i++)                 //заполнение цифрами подряд по определённому
            {                                           //правилу, чтобы выполнить правила судоку
                for (int j = 0; j < 9; j++)
                {
                    mas[i, j] = ++emp + 10;
                    if (emp == 9)
                    {
                        emp = 0;
                    }
                }
                if (mas[i, 0] > 16)
                {
                    emp = mas[i, 0] - 6 - 10;
                }
                else
                {
                    emp = mas[i, 0] + 2 - 10;
                }
            }
            for (int i = 0; i < 50; i++)                //перемешать без нарушения правил
            {
                switch (random.Next(3))
                {
                    case 0:     Camb1();    break;
                    case 1:     Camb2();    break;
                    case 2:     Transp();   break;
                }
            }
            ByeBye();                       //стереть часть чисел
            Console.Beep();
        }

        public void Show()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 9; i++)
            {
                if (i == 6 || i == 3)
                {
                    Console.Write("──────────────────────");
                    Console.WriteLine();
                }
                for (int j = 0; j < 9; j++)
                {
                    if (mas[i, j] == 0)
                        Console.Write("  ");
                    else if (mas[i, j] > 10)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{mas[i, j] % 10} ");
                        Console.ResetColor();
                    }
                    else
                        Console.Write($"{mas[i, j] % 10} ");
                    if (j == 5 || j == 2 || j == 8)
                    {
                        Console.Write("|");
                        Console.Write(" ");
                    }
                        
                }
                Console.WriteLine();
            }
            Console.Write("──────────────────────");

            Console.SetCursorPosition(40, 0);
            Console.Write("Судоку");
            Console.SetCursorPosition(28, 1);
            Console.Write("Расставьте цифры так, чтобы не было");
            Console.SetCursorPosition(28, 2);
            Console.Write("повторений в строке, столбце и блоке.");

            Console.SetCursorPosition(Game.xCursor, Game.yCursor);
        }

        public Boolean Nope(int raw, int column, int num)   //вынесено в отдельный метод,
        {                                                   //чтобы прекращать форы в случае попадания
            Boolean no = false;                 //проверки, что нет такого числа
            for (int i = 0; i < 9; i++)        //в ряду
            {
                if (mas[i, column] % 10 == num)
                {
                    no = true;
                    return no;
                }
            }
            for (int j = 0; j < 9; j++)         //в столбце
            {
                if (mas[raw, j] % 10 == num)
                {
                    no = true;
                    return no;
                }
            }
            for (int j = (column / 3) * 3; j < (column / 3) * 3 + 3; j++)    //в блоке
            {
                for (int i = (raw / 3) * 3; i < (raw / 3) * 3 + 3; i++)
                {
                    if (mas[i, j] % 10 == num)
                    {
                        no = true;
                        return no;
                    }
                }
            }
            if (mas[raw, column] > 10)
                no = true;
            return no;
        }
        public void Change(int raw, int column, int num)
        {
 
            if ( !Nope( raw, column, num))
            {
                mas[raw, column] = num;     //если всё хорошо, то записать
                Show();
                Win();
            }
            else
            {
                Show();
                Console.Beep();             //если нет, то бипнуть
            }
        }
        static void Camb1()                 //методы перемешки
        {
            int block = random.Next(0, 3);
            int row1 = 3 * block;
            int row2 = row1 + random.Next(1, 3);
            for (int j = 0; j < 9; j++)
            {
                int temp = mas[row1, j];
                mas[row1, j] = mas[row2, j];
                mas[row2, j] = temp;
            }
        }
        static void Camb2()
        {
            int block = random.Next(0, 3);
            int column1 = 3 * block;
            int column2 = column1 + random.Next(1, 3);
            for (int i = 0; i < 9; i++)
            {
                int temp = mas[i, column1];
                mas[i, column1] = mas[i, column2];
                mas[i, column2] = temp;
            }
        }

        static void Transp()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    int tmp = 0;
                    tmp = mas[i, j];
                    mas[i, j] = mas[j, i];
                    mas[j, i] = tmp;
                }
            }
        }
        static void ByeBye()                //случайное удаление цифр
        {
            for (int k = 0; k < 54; k++)
            {
                int i = random.Next(0, 9);
                int j = random.Next(0, 9);
                while (mas[i,j] == 0)
                {
                    i = random.Next(0, 9);
                    j = random.Next(0, 9);
                }
                mas[i, j] = 0;
            }
        }

        static void Win()                       //проверка заполненности матрицы
        {
            Boolean win = true;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (mas[i, j] == 0)
                        win = false;
                }
            }
            if (win)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 8);
                Console.WriteLine("YOU WIN!!!");
                Console.ReadKey();
            }
        }
    }
}
