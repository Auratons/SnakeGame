

namespace hw3
{
	public class Direction
	{
        private int _dX;
        private int _dY;

        // Singletons' definitions.
        private static Direction LEFT  = new Direction(0, -1);
        private static Direction UP    = new Direction(-1, 0);
        private static Direction RIGHT = new Direction(0, 1);
        private static Direction DOWN  = new Direction(1, 0);
        
        // Singletons' entry points.
        public static Direction LeftDir() {return LEFT;}
        public static Direction UpDir() {return UP;}
        public static Direction RightDir() {return RIGHT;}
        public static Direction DownDir() {return DOWN;}

        // Class constructor.
		public Direction(int dX, int dY)
		{
            _dX = dX;
            _dY = dY;
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
