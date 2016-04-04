

namespace hw3
{
    class MapTileWine : MapTileEdible
    {
         public MapTileWine(int calories, ILetter graphics) : base(calories, graphics)
        {

        }

        public override void Chewed(Worm worm)
        {
            base.Chewed(worm);
            Game.GetController().Reverse(5000);
        }
    }
}
