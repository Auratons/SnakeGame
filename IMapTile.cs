using System;

namespace hw3
{
	public interface IMapTile
	{
		ILetter GetLetter();
		void Chewed(GameMap map);
	}
}
	