using System;

namespace hw3
{
	public class MapTile
	{
		// Singletons' definitions
		private static IMapTile FREE 	 	= new MapTileEmpty(null);
		private static IMapTile WALL 		= new MapTileEmpty(null);
		private static IMapTile FOOD 		= new MapTileEmpty(null);
		private static IMapTile FOODx2 		= new MapTileEmpty(null);
		private static IMapTile FOODx10 	= new MapTileEmpty(null);
		private static IMapTile POISON 		= new MapTileEmpty(null);
		private static IMapTile WINE 		= new MapTileEmpty(null);
		private static IMapTile WORM_BODY 	= new MapTileEmpty(null);
		private static IMapTile WORM_HEAD 	= new MapTileEmpty(null);

		// Singletons' constructors.
		public static IMapTile GetFree ()
		{ 
			return FREE; 
		}

		public static IMapTile GetWall ()
		{ 
			return WALL; 
		}

		public static IMapTile GetFood ()
		{ 
			return FOOD; 
		}

		public static IMapTile GetFoodx2 ()
		{ 
			return FOODx2; 
		}

		public static IMapTile GetFoodx10 ()
		{ 
			return FOODx10;
		}

		public static IMapTile GetPoison ()
		{ 
			return POISON; 
		}

		public static IMapTile GetWine ()
		{ 
			return WINE;
		}

		public static IMapTile GetWormBody ()
		{ 
			return WORM_BODY;
		}

		public static IMapTile GetWormHead ()
		{ 
			return WORM_HEAD; 
		}
	}
}

