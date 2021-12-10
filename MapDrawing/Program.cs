using System;

namespace MapDrawing
{
    class Program
    {
        static void Main(string[] args)
        {
            int userScore = 0;
            int userXPosition = 3, userYPosition = 3;
            bool isExit = false;
            char[,] map =
            {
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                {'#', ' ', '!', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', 'X', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', '!', ' ', 'X', '!', '#'},
                {'#', ' ', ' ', ' ', ' ', '#', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', '!', ' ', ' ', ' ', ' ', '!', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', '#', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', '#', 'X', '#', ' ', ' ', '!', ' ', ' ', ' ', '#'},
                {'#', ' ', '#', ' ', ' ', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', '!', ' ', '#', ' ', 'X', '!', ' ', ' ', ' ', '#'},
                {'#', ' ', '!', ' ', ' ', 'X', ' ', '!', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
            };
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("Соберите все Х. При касании ! игра заканчивается!");
            Console.SetCursorPosition(0, 0);


            while (isExit == false)
            {
                DrawMap(map, userScore);

                Move(ref userXPosition, ref userYPosition, ref map);

                CollectPoint(ref userXPosition, ref userYPosition, ref map, ref userScore, ref isExit);

                DieFromWall(ref userXPosition, ref userYPosition, ref map, ref isExit);
            }
        }

        static void DrawMap(char[,] map, int sum)
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

        static void Move(ref int userXPosition, ref int userYPosition, ref char[,] map)
        {
            Console.SetCursorPosition(userXPosition, userYPosition);
            Console.Write('@');

            ConsoleKeyInfo charKey = Console.ReadKey();

            switch (charKey.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (map[userYPosition, userXPosition - 1] != '#')
                        userXPosition--;
                    break;
                case ConsoleKey.RightArrow:
                    if (map[userYPosition, userXPosition + 1] != '#')
                        userXPosition++;
                    break;
                case ConsoleKey.UpArrow:
                    if (map[userYPosition - 1, userXPosition] != '#')
                        userYPosition--;
                    break;
                case ConsoleKey.DownArrow:
                    if (map[userYPosition + 1, userXPosition] != '#')
                        userYPosition++;
                    break;
            }
        }

        static void CollectPoint(ref int userXPosition, ref int userYPosition, ref char[,] map, ref int userScore,
            ref bool isExit)
        {
            if (map[userYPosition, userXPosition] == 'X')
            {
                map[userYPosition, userXPosition] = 'O';

                userScore += 1;

                if (userScore == 10)
                {
                    Console.SetCursorPosition(20, 1);
                    Console.WriteLine("Вы собрали все элементы");
                    Console.ReadKey();
                    isExit = true;
                }
            }
        }

        static void DieFromWall(ref int userXPosition, ref int userYPosition, ref char[,] map, ref bool isExit)
        {
            if (map[userYPosition, userXPosition] == '!')
            {
                Console.SetCursorPosition(20, 3);
                Console.WriteLine("Проигрыш!!!");
                Console.ReadKey();
                isExit = true;
            }
        }
    }
}