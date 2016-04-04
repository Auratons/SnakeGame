using System;

namespace hw3
{
	class MainClass
	{
        public static void Main (string[] args)
		{
            int userHeightInt;
            int userWidthInt;
            bool isParameterGiven;

            // Game map dimension insertion.
            Console.WriteLine("This is the Worm game. Please insert height and width (max 80x40, default side length is 40).");
            Console.WriteLine("Height:");
            isParameterGiven = int.TryParse(Console.ReadLine(), out userHeightInt);
            if (!isParameterGiven || (userHeightInt < 1 || userHeightInt > 80))
                userHeightInt = 40;
            Console.WriteLine("Width:");
            isParameterGiven = int.TryParse(Console.ReadLine(), out userWidthInt);
            if (!isParameterGiven || (userHeightInt < 1 || userHeightInt > 40))
                userWidthInt = 40;

            // Game initialization given user defined dimensions.
            Game thisSession = new Game(userHeightInt, userWidthInt);
            thisSession.Run();
        }
	}
}
