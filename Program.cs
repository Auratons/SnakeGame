using System;

namespace hw3
{
	class MainClass
	{
        public int userHeightInt;
        public int userWidthInt;
        bool result;
        string userHeightString;
        string userWidthString;

        public static void Main (string[] args)
		{
            Console.WriteLine("This is the Worm game. Please insert height and width (default 400x400).");
            Console.WriteLine("Height:");
            userHeightString = Console.ReadLine();
            Console.WriteLine("Width:");
            userWidthString = Console.ReadLine();

            result = int.TryParse(userHeightString, out userHeightInt);
            if (!result) userHeightInt = 400;
            result = int.TryParse(userWidthString, out userWidthInt);
            if (!result) userWidthInt = 400;

            Game.Run();
        }
	}
}
