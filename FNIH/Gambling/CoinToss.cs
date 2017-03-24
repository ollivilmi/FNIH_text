using System;

namespace Gambling
{
	public static class CoinToss
	{
		private static Random random = new Random();
		private static int toss;
		public static double gamble(double amount)
		{
			toss = random.Next (1, 3);  //Just a placeholder toincoss program to include some gambling
			if (toss == 1) {
				return amount*2;
			} else
				return 0;
		}
	}
}

