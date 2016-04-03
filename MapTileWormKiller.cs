using System;

namespace hw3
{
	public class MapTileWormKiller : MapTileBase
	{
		public MapTileWormKiller(ILetter graphics) : base(graphics)
		{
			
		}

		public override void Chewed(GameMap map)
		{
            map.GetWorm().Die();
		}
	}
}
	