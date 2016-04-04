

namespace hw3
{
	public class MapTileWormKiller : MapTileBase
	{
		public MapTileWormKiller(ILetter graphics) : base(graphics)
		{
			
		}

		public override void Chewed(Worm worm)
		{
            worm.Die();
		}
	}
}
	