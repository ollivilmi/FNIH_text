using System;
using System.Collections.Generic;

namespace FNIH
{
	public abstract class PlayerDialogue
	{
		private static List<string> dialogue = new List<String>();
		private static int listSize = dialogue.Count;
		private static Random random = new Random();

		public abstract string getDialogue ();
	}
}

