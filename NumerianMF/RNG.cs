using System;

namespace NumerianMF
{
	public static class RNG
	{
		// Random Number Generator
		private static Random random = new Random ();

		public static int RollDie (int sides)
		{
			return random.Next (0, sides) + 1;
		}
	}
}

