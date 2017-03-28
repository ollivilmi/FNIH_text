using System;
using System.Collections.Generic;

namespace Game
{
	public class CharacterSelection
	{
		private string sInput;
		private int input;
	
		public string StartSelection()
		{
			Console.WriteLine ("Characters: Jarno (1), Make (2), Placeholder (3)");
			Console.Write ("Choose character (1-3):");
			sInput = Console.ReadLine ();
			while (int.TryParse (sInput, out input) == false || input > 3 || input < 0) 
			{
				Console.WriteLine ("Use an integer (1-3):");   //Make sure user inputs an integer 1-3
				sInput = (Console.ReadLine ());
			}
			switch (input) {
				case 1:
					return "Jarno";
				case 2:
					return "Make";
				case 3:
					return "Placeholder";
				default:
				return "";
			}
		}
	}
}
