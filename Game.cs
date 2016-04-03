using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3
{
    class Game
    {
        public void Run()
        {
            GameMap map = new GameMap(MainClass., 20);

            map.Render();

            IPlayerController controller = new KeyboardController();

            long lastMillis = 0;

            long nextWormMove = 200;

            while (!controller.IsEndGame())
            {
                controller.Update();
                if (controller.GetInput() != null) lastDirection


            } 
        }


    }
}
