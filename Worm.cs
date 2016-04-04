using System.Collections.Generic;

namespace hw3
{
	public class Worm
	{
		private int growthCount = 0;
        private int caloriesCount = 0;
        private bool alive = true;
        private Location headLocation;
		private Direction heading;
        private Direction previousHeading;
        private Queue<Location> body;

        public Worm(Location headLocation, Direction heading)
        {
            this.headLocation = headLocation;
            this.heading = heading;
            previousHeading = heading;
            body = new Queue<Location>();
            body.Enqueue(headLocation);
        }

		public void Move()
		{
            // Since worm's body is a first in, last out queue,
            // we add new Location of the worm's head and remove
            // the last part of the body as a simulation of movement.
            headLocation = headLocation.GetNextLocation(heading);
            body.Enqueue(headLocation);
            body.Dequeue();
        }

		public void Grow(int i)
		{
            growthCount += 1;
            caloriesCount += i;
            headLocation = headLocation.GetNextLocation(heading);
            body.Enqueue(headLocation);
            // We only add new first head tile location withnout
            // removing the last one as a simulation of one tile growth.
        }

		public void Die()
		{
            alive = false;
		}

		public bool IsAlive()
		{
			return alive;
		}

		public void SetWhereToMoveNext(Direction dir)
		{
            previousHeading = heading;
            if (ReferenceEquals(heading, Direction.UpDir()) || ReferenceEquals(heading, Direction.DownDir()))
            {
                if (ReferenceEquals(dir, Direction.LeftDir()) || ReferenceEquals(dir, Direction.RightDir()))
                {
                    heading = dir;
                }
            }
            else
            {
                if (ReferenceEquals(dir, Direction.UpDir()) || ReferenceEquals(dir, Direction.DownDir()))
                {
                    heading = dir;
                }
            }
        }

        public int GetGrowthCount()
        {
            return growthCount;
        }

        public Location GetHeadLocation()
        {
            return headLocation;
        }

        public Direction GetHeading()
        {
            return heading;
        }

        public Direction GetPreviousHeading()
        {
            return previousHeading;
        }

        public Queue<Location> GetWormBody()
        {
            return body;
        }
    }
}
	