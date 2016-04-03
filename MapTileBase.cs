using System;

namespace hw3
{
	public abstract class MapTileBase : IMapTile
	{
		private ILetter graphics;

		public MapTileBase(ILetter graphics)
		{
			this.graphics = graphics;
		}

		public ILetter GetLetter()
		{
			return graphics;
		}

		public abstract void Chewed(GameMap map);
	}
}
	