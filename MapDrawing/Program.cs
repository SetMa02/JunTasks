using System;

namespace MapDrawing
{
    class Program
    {
        static void Main(string[] args)
        {
                //Сделать игровую карту с помощью двумерного массива.Сделать функцию рисования карты. 
                //Помимо этого, дать пользователю возможность перемещаться по карте и взаимодействовать с элементами
                //(например пользователь не может пройти сквозь стену)
                //Все элементы являются обычными символами
 
            int sum = 0;
            Console.CursorVisible = false;
            char[,] map =
            {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#' },
                {'#',' ','!',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#','X',' ','X',' ',' ',' ',' ',' ',' ','!',' ','X','!','#' },
                {'#',' ',' ',' ',' ','#',' ','X',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ','!',' ',' ',' ',' ','!',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ','#',' ','#',' ','#',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ',' ','#','X','#',' ',' ','!',' ',' ',' ','#' },
                {'#',' ','#',' ',' ','#','#','#',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ','X',' ',' ',' ',' ',' ',' ',' ',' ','X',' ','#' },
                {'#',' ',' ',' ',' ','!',' ','#',' ','X','!',' ',' ',' ','#' },
                {'#',' ','!',' ',' ','X',' ','!',' ',' ',' ',' ',' ',' ','#' },
                {'#','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#' },
            };
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("Соберите все Х. При касании ! игра заканчивается!");
            Console.SetCursorPosition(0, 0);
            int userX = 3, userY = 3;
 
            while (true)
            {
                Draw(map, sum);
 
                Console.SetCursorPosition(userX, userY);
                Console.Write('@');
 
                ConsoleKeyInfo charKey = Console.ReadKey();
 
                switch (charKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (map[userY, userX - 1] != '#')
                            userX--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (map[userY, userX + 1] != '#')
                            userX++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (map[userY - 1, userX] != '#')
                            userY--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (map[userY + 1, userX] != '#')
                            userY++;
                        break;
                }
                if (map[userY, userX] == 'X')
                {
                    map[userY, userX] = 'O';
 
                    sum += 1;
 
                    if (sum == 10)
                    {
                        Console.SetCursorPosition(20, 1);
                        Console.WriteLine("Вы собрали все элементы");
                        Console.ReadKey();
                        break;
                    }
                }
                else if (map[userY, userX] == '!')
                {
                    Console.SetCursorPosition(20, 3);
                    Console.WriteLine("Проигрыш!!!");
                    Console.ReadKey();
                    break;
                }
            }
        }
        static void Draw(char[,] map, int sum)
        {
            Console.SetCursorPosition(20, 0);
            Console.Write("Счетчик: ");
            Console.Write(sum);
 
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}