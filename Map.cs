using System;
using System.Collections.Generic;

namespace hw3
{
	public class Map
	{
        private int height;
        private int width;
		private IMapTile[,] map;
        private List<Location> shouldBeRendered;
        Random randomHeight = new Random();
        Random randomWidth = new Random();

        public Map(int height, int width)
        {
            this.height = height;
            this.width = width;
            map = new IMapTile[height, width];
            shouldBeRendered = new List<Location>();
		}

		public IMapTile GetTile(int height, int width)
		{
			return map[height, width];
		}

        public IMapTile GetTile(Location location)
        {
            return map[location.GetX(), location.GetY()];
        }

		public void SetTile (int height, int width, IMapTile tile)
		{
            if (!(ReferenceEquals(map[height, width], tile)))
            {
                map[height, width] = tile;
                shouldBeRendered.Add(new Location(height, width));
            }
        }
        public void SetTile(Location loc, IMapTile tile)
        {
            SetTile(loc.GetX(), loc.GetY(), tile);
        }

        public int GetHeight ()
        {
            return height;
        }

        public int GetWidth ()
        {
            return width;
        }

        public List<Location> GetRenderList()
        {
            return shouldBeRendered;
        }

        // Helps with placing new FOOD<bla>, WINE, POISON.
        public Location GetRandomFreeTile()
        {
            int nextHeight;
            int nextWidth;

            do
            {
                nextHeight = randomHeight.Next(1, height - 1);
                nextWidth = randomHeight.Next(1, width - 1);
                if (map[nextHeight, nextWidth] is MapTileEmpty)
                {
                    return new Location(nextHeight, nextWidth);
                }
            } while (true);
        }

        public IMapTile RandomSpecial()
        {
            int r = randomHeight.Next(4);

            switch (r)
            {
                case 0:
                    return MapTile.GetFoodx2();
                case 1:
                    return MapTile.GetFoodx10();
                case 2:
                    return MapTile.GetWine();
                default:
                    return MapTile.GetPoison();
            }
        }
    }
}
