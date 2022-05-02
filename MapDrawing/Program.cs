using System;

namespace MapDrawing
{
    class Program
    {
        static void Main(string[] args)
        {
            int userScore = 0;
            int userXPosition = 3, userYPosition = 3;
            int directionX = 0;
            int directionY = 0;
            int pointToWin = 10;
            bool isExit = false;
            char[,] map =
            {
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                {'#', ' ', '!', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', 'X', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', '!', 'X', ' ', '!', '#'},
                {'#', ' ', ' ', ' ', ' ', '#', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', '!', ' ', ' ', ' ', ' ', '!', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', '#', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', '#', 'X', '#', ' ', ' ', '!', ' ', ' ', ' ', '#'},
                {'#', ' ', '#', ' ', ' ', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', '!', ' ', '#', ' ', 'X', '!', 'X', ' ', ' ', '#'},
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
                
                DrawPlayer(userXPosition, userYPosition);

                GetDirection(out directionX, out directionY, userXPosition, userYPosition);
                
                MoveToDirection( directionX, directionY,ref userXPosition, ref userYPosition, map);

                CollectPoint( userXPosition,  userYPosition, map, ref userScore);

                if (CheckUserPoints(userScore, pointToWin) == true)
                {
                    WinGame(ref isExit);
                }
                
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

        static void DrawPlayer(int userXPosition,int userYPosition)
        {
            Console.SetCursorPosition(userXPosition, userYPosition);
            Console.Write("@");
        }

        static void GetDirection(out int userXposition, out int userYposition, int xPosition,int yPosition)
        {
            userXposition = xPosition;
            userYposition = yPosition;
            
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                    userXposition--;
                    break;
                case ConsoleKey.RightArrow:
                    userXposition++;
                    break;
                case ConsoleKey.UpArrow:
                   userYposition--;
                    break;
                case ConsoleKey.DownArrow:
                    userYposition++;
                    break;
            }
        }

        static void MoveToDirection(int directionX, int directionY,ref int userXPosition, ref int userYPosition, char[,] map)
        {

            if (map[directionX,directionY] != '#')
            {
                userXPosition = directionX;
                userYPosition = directionY;
            }
        }

        static bool CheckUserPoints( int userScore, int pointsToWin)
        {
            if (userScore == pointsToWin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void WinGame(ref bool isExit)
        {
            Console.WriteLine("Вы собрали все элементы");
            Console.ReadKey();
            isExit = true;
        }

        static void CollectPoint( int userXPosition,  int userYPosition, char[,] map,ref int userScore)
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