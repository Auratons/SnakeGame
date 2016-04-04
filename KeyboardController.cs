using System;

namespace hw3
{
    class KeyboardController : IPlayerController
    {
        private Direction input;
        private static KeyboardController keyboard = new KeyboardController();
        private bool endGame = false;
        private DateTime endOfReverseControl = DateTime.Now;

        public static KeyboardController GetKeyboard()
        {
            return keyboard;
        }

        private void ReadKey(ConsoleKeyInfo? v)
        {
            if (v == null) return    ;                 
            ConsoleKeyInfo key = v.GetValueOrDefault();

            if (key.Key == ConsoleKey.A ||
                key.Key == ConsoleKey.NumPad4 ||
                key.Key == ConsoleKey.LeftArrow ||
                key.Key == ConsoleKey.D4)
            {
                SetDirection(Direction.LeftDir());
                return;
            }
            if (key.Key == ConsoleKey.S ||
                key.Key == ConsoleKey.NumPad2 ||
                key.Key == ConsoleKey.DownArrow ||
                key.Key == ConsoleKey.D2)
            {
                SetDirection(Direction.DownDir());
                return;
            }
            if (key.Key == ConsoleKey.D ||
                key.Key == ConsoleKey.NumPad6 ||
                key.Key == ConsoleKey.RightArrow ||
                key.Key == ConsoleKey.D6)
            {
                SetDirection(Direction.RightDir());
                return;
            }
            if (key.Key == ConsoleKey.W ||
                key.Key == ConsoleKey.NumPad8 ||
                key.Key == ConsoleKey.UpArrow ||
                key.Key == ConsoleKey.D8)
            {
                SetDirection(Direction.UpDir());
                return;
            }
            if (key.Key == ConsoleKey.Escape)
            {
                endGame = true;
                return;
            }
        }
        public void Update()
        {
            while (Keyboard.GetKeyboard().HasKey())
            {
                ReadKey(Keyboard.GetKeyboard().GetKey());
            }
        }

        public void Reverse(long miliseconds)
        {
            endOfReverseControl = DateTime.Now.AddMilliseconds(miliseconds);
        }

        public Direction GetInput()
        {
            return input;
        }

        public void SetDirection(Direction dir)
        {
            if (IsReversed())
            {
                if (ReferenceEquals(dir, Direction.LeftDir())) { input = Direction.RightDir(); }
                if (ReferenceEquals(dir, Direction.RightDir())) { input = Direction.LeftDir(); }
                if (ReferenceEquals(dir, Direction.UpDir())) { input = Direction.DownDir(); }
                if (ReferenceEquals(dir, Direction.DownDir())) { input = Direction.UpDir(); }
            }
            else
            {
                input = dir;
            }
        }


        public bool IsEndGame()
        {
            return endGame;
        }

        public bool IsReversed()
        {
            if (endOfReverseControl > TimeDelta.GetTimer().Current())
            {
                return true;
            }
            return false;
        }
    }
}
