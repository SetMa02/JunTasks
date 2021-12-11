using System;

namespace MapDrawing
{
    class Program
    {
        static void Main(string[] args)
        {
            int userScore = 0;
            int userXPosition = 3, userYPosition = 3;
            int pointToWin = 10;
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
                string direction;
                
                DrawMap(map, userScore);

                direction = GetDirection(userXPosition, userYPosition);
                
                MoveToDirection(direction, ref userXPosition, ref userYPosition, map);

                CollectPoint(ref userXPosition, ref userYPosition, map, ref userScore);
                
                CheckUserPoints(ref isExit, userScore, pointToWin);

                CheckWallCollide(ref userXPosition, ref userYPosition, map, ref isExit);
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

        static string GetDirection(int userXPosition, int userYPosition)
        {
            Console.SetCursorPosition(userXPosition, userYPosition);
            Console.Write("@");
            
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                    return "left";
                    break;
                case ConsoleKey.RightArrow:
                    return "right";
                    break;
                case ConsoleKey.UpArrow:
                    return "up";
                    break;
                case ConsoleKey.DownArrow:
                    return "down";
                    break;
            }
            return null;
        }

        static void MoveToDirection(string direction,ref int userXPosition, ref int userYPosition, char[,] map)
        {
            
            switch (direction)
            {
                case "left":
                    if (map[userYPosition, userXPosition - 1] != '#')
                        userXPosition--;
                    break;
                case "right":
                    if (map[userYPosition, userXPosition + 1] != '#')
                        userXPosition++;
                    break;
                case "up":
                    if (map[userYPosition - 1, userXPosition] != '#')
                        userYPosition--;
                    break;
                case "down":
                    if (map[userYPosition + 1, userXPosition] != '#')
                        userYPosition++;
                    break;
            }
        }

        static void CheckUserPoints(ref bool isExit, int userScore, int pointsToWin)
        {
            if (userScore == pointsToWin)
            {
                Console.SetCursorPosition(20, 1);
                Console.WriteLine("Вы собрали все элементы");
                Console.ReadKey();
                isExit = true;
            }
        }

        static void CollectPoint(ref int userXPosition, ref int userYPosition, char[,] map,ref int userScore)
        {
            if (map[userYPosition, userXPosition] == 'X')
            {
                map[userYPosition, userXPosition] = 'O';
                userScore += 1;
            }
        }

        static void CheckWallCollide(ref int userXPosition, ref int userYPosition, char[,] map, ref bool isExit)
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