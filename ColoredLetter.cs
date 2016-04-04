using System;

namespace hw3
{
	public class ColoredLetter : ILetter
	{
		private char character;
		private ConsoleColor foreground;
		private ConsoleColor background;

		public ColoredLetter(ConsoleColor foreground, ConsoleColor background, char character)
		{
			this.foreground = foreground;
			this.background = background;
			this.character = character;
		}

		public char GetChar()
		{
			return character;
		}

		public ConsoleColor GetForegroundColor()
		{
			return foreground;
		}

		public ConsoleColor GetBackgroundColor()
		{
			return background;
		}

		public void Write()
		{
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
            Console.Write(character);
		}
	}
}
