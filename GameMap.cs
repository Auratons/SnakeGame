using System;

namespace hw3
{
	public class GameMap
	{
        /// <summary>
        /// This class contain the map and the worm, controls all rendering,
        /// placing of tiles and movement done on the map.
        /// </summary>
        
		private Map map;
		private Worm worm;
        private Random randomHeight = new Random();
        private Random randomWidth = new Random();
        private Location place;
        private IMapTile specialType;
        private Location specialLocation;
        private DateTime specialEndTime;
        private long runTime;

        public Map GetMap()
        {
            return map;
        }

        public Worm GetWorm()
        {
            return worm;
        }

        // After the game start sets the whole map, provides
        // first render of the setup.
        public GameMap(int height, int width)
        {
            // Map and console size initialization.
            map = new Map(height, width);
            Console.SetWindowSize(width, height + 1);
            Console.SetWindowPosition(1, 1);
            Console.SetCursorPosition(0, 0);

            // Setting inside of the map to free tiles.
            for (int i = 1; i < height-1; ++i)
            {
                for (int j = 1; j < width-1; ++j)
                {
                    map.SetTile(i, j, MapTile.GetFree());
                }
            }

            // Setting walls around the map horizontally.
            for (int i = 0; i < height; i++)
            {
                map.SetTile(i, 0,       MapTile.GetWall());
                map.SetTile(i, width-1, MapTile.GetWall());
            }

            // Setting walls around the map vertically.
            for (int i = 0; i < width; i++)
            {
                map.SetTile(0,        i, MapTile.GetWall());
                map.SetTile(height-1, i, MapTile.GetWall());
            }

            // Placing of the worm head and first food.
            worm = new Worm(new Location(height / 2, width / 2), Direction.UpDir());
            place = map.GetRandomFreeTile();
            map.SetTile(place.GetX(), place.GetY(), MapTile.GetFood());

            // The first render.
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(0, i);
                for (int j = 0; j < width; j++)
                {
                    map.GetTile(i, j).GetLetter().Write();
                }
            }

            // Render of the information line.
            Console.SetCursorPosition(1, height);
            Console.ResetColor();
            runTime = TimeDelta.GetTimer().Delta();
            Console.Write("Length: {0}      Time: {1}:{2}",
                worm.GetGrowthCount(), runTime / 60, runTime % 60);
            Console.SetCursorPosition(0, 0);
        } // GameMap constructor.


        public void Render()
		{
            // Render of all changes made on the map.
            foreach (Location location in map.GetRenderList())
            {
                // Since SetCursorPosition does not fullfill normal
                // matrix coordinates [row, column], but [column, row],
                // it is necesarry to switch them. Time to find bug: 5 h.
                Console.SetCursorPosition(location.GetY(), location.GetX());
                map.GetTile(location).GetLetter().Write();
            }
            map.GetRenderList().Clear();

            // Render of the information line.
            Console.SetCursorPosition(0, map.GetHeight());
            Console.ResetColor();
            runTime = TimeDelta.GetTimer().Delta();
            Console.Write("Length: {0}      Time: {1,2}:{2,2}",
                worm.GetGrowthCount(), runTime / 60, runTime % 60);
            Console.SetCursorPosition(0, 0);
        }

        // Main algorithm part, takes map from previous map status
        // in previous time quantum (gamePeriod from Game class),
        // simlulates all moves of the worm given user's commands
        // and transforms map[,] array with new tiles. Simultaneously
        // writes all changes to map.shouldBeRendered[] which provides
        // Render methods material for rendering console.
        public void Step(Direction dir)
        {
            IMapTile tmpTile;

            worm.SetWhereToMoveNext(dir);
            map.SetTile(worm.GetHeadLocation(), MapTile.GetBodyPart(worm.GetPreviousHeading(), worm.GetHeading()));
            tmpTile = map.GetTile(worm.GetHeadLocation().GetNextLocation(worm.GetHeading()));
            if (!(tmpTile is MapTileEdible))
            {
                map.SetTile(worm.GetWormBody().Peek(), MapTile.GetFree());
            }
            tmpTile.Chewed(worm);
            map.SetTile(worm.GetHeadLocation(), MapTile.GetHead(worm.GetHeading()));
            if (ReferenceEquals(tmpTile, MapTile.GetFood()))
            {
                place = map.GetRandomFreeTile();
                map.SetTile(place, MapTile.GetFood());
            }
        }

        public void PlaceSpecialAtRandomFreePlace(long millis)
        {
            // Sometimes checks if should place special tile and if there is not any.
            // We don't want more special tiles in very moment on the map.
            if (randomHeight.Next(10) == 0 && specialLocation == null)
            {   
                // Choose one from special tiles.
                specialType = map.RandomSpecial();
                // Finds appropriate position for new tile.
                specialLocation = map.GetRandomFreeTile();
                // Amends map[,] array with new tile.
                map.SetTile(specialLocation, specialType);
                // Sets time by which the tile should be removed.
                specialEndTime = TimeDelta.GetTimer().RealCurrent().AddMilliseconds(millis);
            }
            // It is time to place a ne special tile.
            else if (specialEndTime < TimeDelta.GetTimer().Current() && (specialLocation != null))
            {
                // We just need to find out if type of tile on specialLocation agrees,
                // because we could have eaten it before calling this method again.
                if (ReferenceEquals(specialType, map.GetTile(specialLocation)))
                {
                    // If it is still in place, we revert it again to FREE tile.
                    map.SetTile(specialLocation, MapTile.GetFree());
                }
                // Else we have eaten it, besides, we need to tell that the next time
                // it is possible to place a new one.
                specialLocation = null;
            }
        }
	}
}
	