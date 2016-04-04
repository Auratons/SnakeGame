using System;

namespace hw3
{
    class Game
    {
        private static IPlayerController controller;
        private GameMap map;
        private int basePeriod = 300;
        private int gamePeriod;

        public Game(int height, int width)
        {
            map = new GameMap(height, width);
            controller = KeyboardController.GetKeyboard();
        }

        // Controls game flow, main infinite cycle running until game over or Esc.
        public void Run()
        {
            while (true)
            {
                // Firstly checks if should we do something.
                if (TimeDelta.GetTimer().RealDelta() > gamePeriod)
                {
                    // Secondly updates current time in Timer, reads last key pressed
                    // and checks if the game is not about to end.
                    TimeDelta.GetTimer().Update();

                    if (map.GetWorm().IsAlive() && !(controller.IsEndGame()))
                    {
                        controller.Update();
                        // Now in controller.GetInput().d[X,Y]() we have relative 
                        // directions of movement.

                        map.Step(controller.GetInput());
                        map.PlaceSpecialAtRandomFreePlace(5000);
                        map.Render();
                        // The game must get faster and faster.
                        gamePeriod = basePeriod - (map.GetWorm().GetGrowthCount() / 5) * 25;
                    }
                    else
                        break;
                }
            }
        }

        public static IPlayerController GetController()
        {
            return controller;
        }
    }
}
