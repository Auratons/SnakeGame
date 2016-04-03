using System;

namespace hw3
{
	public class Worm
	{
		private int growthCount = 0;
		private Location location;
		private Direction direction;
		private bool alive = true;

        public List<Tuple<int, int>> body;

		public Worm (int growthCount,Location location,Direction direction,bool alive) // (in x, int y)
		{
			this.growthCount = growthCount;
			this.location = location; // tuple
			this.direction = direction;
			this.alive = alive;


            //hodina

            body = new List<Tuple<int, int>>();

            body.Add(new Tuple<int, int>(x, y));

        }

		public void Move (GameMap map)
		{
            Tuple<int, int> head = body[body.Count - 1];

            Tuple<int, int> newHead = new Tuple<int, int>(head.Item1 + direction.dX(), head.Item2 = direction.dY());

            // zkontrolovat jestli nejsem mimo mapu

            IMapTile tile = map.GetMap().GetTile(newHead.Item1, newHead.Item2);

            tile.Chewed(map);

            //zkontrolovat jestli jsem se nekousl sam for cyklus

            //musime se pohnout
            body.Add(newHead);
            if (growthCount > 0)
            {
                //togrow
            } else
            {
                body.RemovaAt(0);
            }

            // delta rendering
        }

        //render 

		public void Grow (int i)
		{
            this.growthCount += i;
		}

		public void Die ()
		{
            alive = false;
		}

		public bool IsAlive ()
		{
			return alive;
		}

		public int GetGrowthCount ()
		{
			return growthCount;
		}

		public Location GetLocation ()
		{
			return location;
		}

		public Direction GetDirection ()
		{
			return direction;
		}

		public void SetHeading (Direction dir)
		{

		}
	}
}
	