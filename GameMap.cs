using System;

namespace hw3
{
	public class GameMap
	{
		private Map map;
		private Worm worm;

		public GameMap (Map map,Worm worm)
		{
			this.map = map;
			this.worm = worm;
		}
        public GameMap(int width, int height)
        {
            Map map = new Map(width, height);

            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    map.SetTile();
                }
            }
        }


        public void Render ()
		{
            for (int x = 0; x < map.GetWidth(); ++x)
            {
                for (int y =0; y < map.GetWidth(); ++y)
                {
                    // vykreslit 
                }
            }
		}

		public Map GetMap ()
		{
			return map;
		}

		public void PlaceAtRandomFree (IMapTile tile)
		{

		}

		public Worm GetWorm ()// umoznuje mi dostat odkaz na worm v jine tride, abych s nim mohl pracovat
		{
			return worm;
		}
	}
}
	