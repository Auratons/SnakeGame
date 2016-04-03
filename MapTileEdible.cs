using System;

namespace hw3
{
	public class MapTileEdible : MapTileBase
	{
		private int calories;

		public MapTileEdible(int calories, ILetter graphics) : base(graphics)
		{
			this.calories = calories;
		}

		public int GetCalories()
		{
			return calories;
		}

		public override void Chewed(GameMap map)
		{
            map.GetWorm().Grow(calories);
            map.PlaceAtRandomFree(this);
		}
	}
}
