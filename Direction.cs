using System;

namespace hw3
{
	public class Direction
	{
        // Singletons' definitions.
        private static Direction LEFT  = new Direction(-1, 0);
        private static Direction UP    = new Direction(0, -1);
        private static Direction RIGHT = new Direction(1, 0);
        private static Direction DOWN  = new Direction(0, 1);

        private int _dX;
        private int _dY;
        
        // Singletons' constructors.
        public static Direction LeftDir()
        {
            return LEFT;
        }

        public static Direction UpDir()
        {
            return UP;
        }

        public static Direction RightDir()
        {
            return RIGHT;
        }

        public static Direction DownDir()
        {
            return DOWN;
        }

        // Class constructor.
		public Direction (int dX, int dY)
		{
            this._dX = dX;
            this._dY = dY;
		}

        public int dX()
        {
            return _dX;
        }

        public int dY()
        {
            return _dY;
        }
	}
}

