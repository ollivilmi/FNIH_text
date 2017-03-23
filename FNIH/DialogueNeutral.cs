﻿using System;
using System.Collections.Generic;

namespace FNIH
{
	public static class DialogueNeutral
	{
		private static List<string> neutral = new List<string> () { 
			"Yep.", 
			"Ok.", 
			"Mmhm.",
			"Certainly.",
			"I guess.",
			"I suppose.",
			"I agree." };
		private static int listSize = neutral.Count;
		private static Random random = new Random();

		public static int getDialogue() {
			Console.WriteLine("Answer: "+neutral[random.Next(0,listSize)]);
			return 2;
		}
	}
}

