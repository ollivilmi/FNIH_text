using System;
using System.Collections.Generic;
using Dialogue;

namespace NPC
{
	public class BarNPC : NPC
	{
		private DialogueController dialogue;
		public BarNPC ()
		{
			mood = random.Next (0, 101);
			Items = new List<string>() { "Phone number" };
			dialogue = new DialogueController ();
		}

		override public void StartDialogue(int likability)
		{
			mood += dialogue.startDialogue (likability);

		}

		public void ReturnItems(out string item)
		{
			if (mood == 100) {	
				item = Items [0]; 				//Return phone number
				Items.Remove ("Phone number");		//Remove phone number from list
				return;
			} else if (mood >= 80 && mood < 100) {
				Console.WriteLine ("Very happy.");

			} else if (mood >= 60 && mood < 80) {
				Console.WriteLine ("Happy.");

			} else if (mood >= 40 && mood < 60) {
				Console.WriteLine ("Neutral.");

			} else if (mood >= 20 && mood < 40) {
				Console.WriteLine ("Negative.");

			} else if (mood < 20) {
				Console.WriteLine ("Very negative.");
			}
			item = "";
		}
	}
}

