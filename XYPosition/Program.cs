using System;

namespace XYPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int _mapXLength;
            int _mapYLength;

            _mapXLength = 10;
            _mapYLength = 10;

            Player player = new Player();
            PlayerRender render = new PlayerRender();

            for (int i = 1; i < _mapXLength; i++)
            {
                for (int j = 1; j < _mapYLength; j++)
                {
                    Console.Write(".");
                }
                Console.WriteLine();
            }
            render.SetThePlayer(player);
        }
    }

    class Player
    {
        private int _xPlayerPosition;
        private int _yPlayerPosition;
        public int XPlayerPosition => _xPlayerPosition;
        public int YPlayerPosition => _yPlayerPosition;

        public Player()
        {
           _xPlayerPosition = 2;
            _yPlayerPosition = 4;
        }
        
        public Player(int xPlayerPosition, int yPlayerPosition)
        {
            _xPlayerPosition = xPlayerPosition;
            _yPlayerPosition = yPlayerPosition;
        }
    }

    class PlayerRender
    {
        public void SetThePlayer(Player player)
        {
            Console.SetCursorPosition(player.XPlayerPosition, player.YPlayerPosition);
            Console.Write("#");
        }
    }
}