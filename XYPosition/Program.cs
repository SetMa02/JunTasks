using System;

namespace XYPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Map draw = new Map();
            
            draw.DrawPlayerInMap(player);
        }
    }

    class Player
    {
        private int _xPositionPosition;

        public int XPositionPosition => _xPositionPosition;
        
        private int _yPositionPosition;
        public int YPositionPosition => _yPositionPosition;

        public Player()
        {
           _xPositionPosition = 1;
            _yPositionPosition = 2;
        }
        
        public Player(int xPosition, int yPosition)
        {
            _xPositionPosition = xPosition;
            _yPositionPosition = yPosition;
        }
    }

    class Map
    {
        private int _mapXLength;
        private int _mapYLength;
        
        public Map()
        {
            _mapXLength = 10;
            _mapYLength = 10;
        }
        
        public Map(int xLenghts,int yLenghts)
        {
            _mapXLength = xLenghts;
            _mapYLength = yLenghts;
        }
        public void DrawPlayerInMap(Player player)
        {
            for (int i = 1; i <= _mapXLength ; i++)
            {
                for (int j = 1; j <= _mapYLength; j++)
                {
                    if (i == player.XPositionPosition && j == player.YPositionPosition) 
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}