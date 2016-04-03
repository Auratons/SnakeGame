using System;

namespace hw3
{
	public class Map
	{
        private int height;
        private int width;
		private IMapTile[,] map;

		public Map (int height, int width)
		{
            this.height = height;
            this.width = width;
            map = new IMapTile[width, height];
		}

		public IMapTile GetTile (int height, int width)
		{
			return map[height, width];
		}

		public void SetTile (int height, int width)
		{
 
		}

        public int GetHeight ()
        {
            return height;
        }

        public int GetWidth ()
        {
            return width;
        }
        
	}
}

