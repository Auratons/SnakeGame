

namespace hw3
{
	public class Location
	{
        private int height;
        private int width;

		public Location(int height, int width)
		{
            this.height = height;
            this.width = width;
		}

        public int GetX()
        {
            return height;
        }

        public int GetY()
        {
            return width;
        }

        public Location GetNextLocation(Direction direction)
        {
            return new Location(height + direction.dX(),
                                width + direction.dY());
        }
    }
}

