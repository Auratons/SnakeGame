

namespace hw3
{
	public class MapTileEmpty : MapTileBase
	{
		public MapTileEmpty(ILetter graphics) : base(graphics)
		{
			
		}

		public override void Chewed(Worm worm)
		{
            worm.Move();
		}
	}
}

