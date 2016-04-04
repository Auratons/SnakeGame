using System;

namespace hw3
{
    class Keyboard
    {
        // Singleton definition
        private static Keyboard instance = new Keyboard();

        // Singleton constructor
        public static Keyboard GetKeyboard()
        {
            return instance;
        }

        public bool HasKey()
        {
            return Console.KeyAvailable;
        }

        public ConsoleKeyInfo? GetKey()
        {
            if (HasKey())
            {
                return Console.ReadKey(true);
            }
            return null;
        }
    }
}
