using System;

namespace hw3
{
	public static class MapTile
	{
		// Singletons' definitions
		private static IMapTile FREE 	 	= 
            new MapTileEmpty(new ColoredLetter(ConsoleColor.White, ConsoleColor.DarkYellow, ' '));
		private static IMapTile WALL 		= 
            new MapTileWormKiller(new ColoredLetter(ConsoleColor.Black, ConsoleColor.Cyan, '+'));
		private static IMapTile FOOD 		= 
            new MapTileEdible(2, new ColoredLetter(ConsoleColor.DarkGreen,ConsoleColor.White,'F'));
		private static IMapTile FOODx2 		= 
            new MapTileEdible(4, new ColoredLetter(ConsoleColor.Magenta, ConsoleColor.White, 'o'));
		private static IMapTile FOODx10 	= 
            new MapTileEdible(20, new ColoredLetter(ConsoleColor.DarkGreen, ConsoleColor.Green, 'O'));
		private static IMapTile POISON 		= 
            new MapTileWormKiller(new ColoredLetter(ConsoleColor.DarkRed, ConsoleColor.White, 'P'));
		private static IMapTile WINE 		= 
            new MapTileWine(10, new ColoredLetter(ConsoleColor.DarkCyan, ConsoleColor.White, 'W'));
		private static IMapTile WORM_HEAD_DOWN 	= 
            new MapTileWormKiller(new ColoredLetter(ConsoleColor.DarkBlue, ConsoleColor.White, 'v'));
        private static IMapTile WORM_HEAD_UP =
            new MapTileWormKiller(new ColoredLetter(ConsoleColor.DarkBlue, ConsoleColor.White, '^'));
        private static IMapTile WORM_HEAD_RIGHT =
            new MapTileWormKiller(new ColoredLetter(ConsoleColor.DarkBlue, ConsoleColor.White, '>'));
        private static IMapTile WORM_HEAD_LEFT =
            new MapTileWormKiller(new ColoredLetter(ConsoleColor.DarkBlue, ConsoleColor.White, '<'));
        private static IMapTile WORM_BODY_HORIZONTAL =
            new MapTileWormKiller(new ColoredLetter(ConsoleColor.DarkBlue, ConsoleColor.White, '–'));
        private static IMapTile WORM_BODY_VERTICAL =
            new MapTileWormKiller(new ColoredLetter(ConsoleColor.DarkBlue, ConsoleColor.White, '|'));
        private static IMapTile WORM_BODY_RIGHT =
            new MapTileWormKiller(new ColoredLetter(ConsoleColor.DarkBlue, ConsoleColor.White, '/'));
        private static IMapTile WORM_BODY_LEFT =
            new MapTileWormKiller(new ColoredLetter(ConsoleColor.DarkBlue, ConsoleColor.White, '\\'));
        
        // Singletons' entrance points.
        public static IMapTile GetFree()     {return FREE;}
		public static IMapTile GetWall()     {return WALL;}
		public static IMapTile GetFood()     {return FOOD;}
		public static IMapTile GetFoodx2()   {return FOODx2;}
		public static IMapTile GetFoodx10()  {return FOODx10;}
		public static IMapTile GetPoison()   {return POISON;}
		public static IMapTile GetWine()     {return WINE;}
		public static IMapTile GetWormBodyHorizontal() {return WORM_BODY_HORIZONTAL;}
        public static IMapTile GetWormBodyVertical()   {return WORM_BODY_VERTICAL;}
        public static IMapTile GetWormBodyRight()      {return WORM_BODY_RIGHT;}
        public static IMapTile GetWormBodyLeft()       {return WORM_BODY_LEFT;}
        public static IMapTile GetWormHeadDown()       {return WORM_HEAD_DOWN;}
        public static IMapTile GetWormHeadUp()         {return WORM_HEAD_UP;}
        public static IMapTile GetWormHeadRight()      {return WORM_HEAD_RIGHT;}
        public static IMapTile GetWormHeadLeft()       {return WORM_HEAD_LEFT;}

        public static IMapTile GetBodyPart(Direction previousDir, Direction dir)
        {
            if (ReferenceEquals(previousDir, Direction.LeftDir()))
            {
                if (ReferenceEquals(dir, Direction.LeftDir()))  {return WORM_BODY_HORIZONTAL;}
                if (ReferenceEquals(dir, Direction.UpDir()))    {return WORM_BODY_LEFT;}
                if (ReferenceEquals(dir, Direction.DownDir()))  {return WORM_BODY_RIGHT;}
            }
            if (ReferenceEquals(previousDir, Direction.UpDir()))
            {
                if (ReferenceEquals(dir, Direction.LeftDir()))  {return WORM_BODY_LEFT;}
                if (ReferenceEquals(dir, Direction.RightDir())) {return WORM_BODY_RIGHT;}
                if (ReferenceEquals(dir, Direction.UpDir()))    {return WORM_BODY_VERTICAL;}
            }
            if (ReferenceEquals(previousDir, Direction.RightDir()))
            {
                if (ReferenceEquals(dir, Direction.RightDir())) {return WORM_BODY_HORIZONTAL;}
                if (ReferenceEquals(dir, Direction.UpDir()))    {return WORM_BODY_RIGHT;}
                if (ReferenceEquals(dir, Direction.DownDir()))  {return WORM_BODY_LEFT;}
            }
            if (ReferenceEquals(previousDir, Direction.DownDir()))
            {
                if (ReferenceEquals(dir, Direction.LeftDir()))  {return WORM_BODY_RIGHT;}
                if (ReferenceEquals(dir, Direction.RightDir())) {return WORM_BODY_LEFT;}
                if (ReferenceEquals(dir, Direction.DownDir()))  {return WORM_BODY_VERTICAL;}
            }
            return null;
        }

        public static IMapTile GetHead(Direction dir)
        {
            if (ReferenceEquals(dir, Direction.LeftDir()))  {return WORM_HEAD_LEFT;}
            if (ReferenceEquals(dir, Direction.UpDir()))    {return WORM_HEAD_UP;}
            if (ReferenceEquals(dir, Direction.RightDir())) {return WORM_HEAD_RIGHT;}
            if (ReferenceEquals(dir, Direction.DownDir()))  {return WORM_HEAD_DOWN;}
            return null;
        }
    }
}

