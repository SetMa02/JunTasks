using System;

namespace XYPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Draw draw = new Draw();
            
            draw.DrawPlayerInMap(player);
        }
    }

    class Player
    {
        public int xPosition;
        public int yPosition;

        public Player()
        {
            xPosition = 1;
            yPosition = 2;
        }
        
        public Player(int x, int y)
        {
            xPosition = x;
            yPosition = y;
        }
    }

    class Draw
    {
        private char[,] map =
        {
            {'.','.','.','.','.','.','.','.'},
            {'.','.','.','.','.','.','.','.'},
            {'.','.','.','.','.','.','.','.'},
            {'.','.','.','.','.','.','.','.'},
            {'.','.','.','.','.','.','.','.'},
            {'.','.','.','.','.','.','.','.'},
            {'.','.','.','.','.','.','.','.'},
            {'.','.','.','.','.','.','.','.'},
            {'.','.','.','.','.','.','.','.'},
            {'.','.','.','.','.','.','.','.'}
        };

        public void DrawPlayerInMap(Player player)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(player.xPosition -1, player.yPosition -1);
            Console.Write("#");
        }
    }
}