using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3
{
    class KeyboardController : IPlayerController
    {
        Direction lastInput;
        bool endGame = false;

        public void Update()
        {
            Keyboard keyboard = Keyboard.GetKeyboard();

            lastInput = null;
            endGame = false;

            while (keyboard.HasKey())
            {
                ReadKey(keyboard.GetKey());
            }
        }

        private void ReadKey(ConsoleKeyInfo? v)
        {
            if (v == null) return   ;
            
            ConsoleKeyInfo key = v.GetValueOrDefault();

            switch (key.KeyChar)
            {
                case 'A':
                case 'a':
                    lastInput = Direction.LeftDir();
                    break;
                case 'S':
                case 's':
                    lastInput = Direction.DownDir();
                    break;
                case 'D':
                case 'd':
                    lastInput = Direction.RightDir();
                    break;
                case 'W':
                case 'w':
                    lastInput = Direction.UpDir();
                    break;
            }

            if (key.Key == ConsoleKey.Escape)
            {
                endGame = true;
            }
        }
    }
}
