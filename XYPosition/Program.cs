using System;

namespace XYPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int mapXLength;
            int mapYLength;

            mapXLength = 10;
            mapYLength = 10;

            Player player = new Player();
            PlayerRender render = new PlayerRender();

            
            for (int i = 1; i < mapXLength; i++)
            {
                for (int j = 1; j < mapYLength; j++)
                {
                    Console.Write(".");
                }
                Console.WriteLine();
            }
            render.ShowPlayer(player);
        }
    }

    class Player
    {
        private int _xPosition;
        private int _yPosition;
        public int XPosition => _xPosition;
        public int YPosition => _yPosition;

        public Player()
        {
           _xPosition = 2;
            _yPosition = 4;
        }
        
        public Player(int xPosition, int yPosition)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
        }
    }

    class PlayerRender
    {
        public void ShowPlayer(Player player)
        {
            Console.SetCursorPosition(player.XPosition, player.YPosition);
            Console.Write("#");
            Console.SetCursorPosition(0, 0);
            
        }
    }
}