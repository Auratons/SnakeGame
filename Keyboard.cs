using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3
{
    class Keyboard
    {
        // Singleton definition
        private static Keyboard instance;

        // Singleton constructor
        public static Keyboard GetKeyboard()
        {
            if (instance == null)
            {
                instance = new Keyboard();
            }
            return instance;
        }

        private Keyboard() {}

        public bool HasKey()
        {
            return Console.KeyAvailable;
        }

        public ConsoleKeyInfo? GetKey()
        {
            if (HasKey())
            {
                return Console.ReadKey(true).Key;
            }
            return null;
        }

        public void Reverse(long miliseconds)
        {

        }
    }
}
