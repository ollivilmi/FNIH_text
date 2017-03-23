using System;
using System.Collections.Generic;

namespace FNIH
{
	public static class DialoguePositive
	{
		private static List<string> positive = new List<string> () { 
			"You are very funny.", 
			"Hahaha.",
			"Are you always this awesome?",
			"You are shining.",
			"Hehehehe.",
			"Hey, you look great." };
		private static int listSize = positive.Count;
		private static Random random = new Random();

		public static string getDialogue() {
			Console.WriteLine("Answer: "+positive[random.Next(0,listSize)]);
			return "Positive";
		}
	}
}

