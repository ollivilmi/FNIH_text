using System;
using System.Collections.Generic;
using Dialogue;

namespace NPC
{
	public class BarNPC : NPC
	{
		private DialogueController dialogue;
		private int x;
		public BarNPC ()
		{
			mood = random.Next (0, 101);
			items = new List<string>() { "Love letter", "Phone number" };
			dialogue = new DialogueController ();
			x = items.Count - 1;
		}

		override public void StartDialogue(int likability)
		{
			mood += dialogue.startDialogue (likability);
		}

		public void ReturnItems(out string item)
		{
			if (mood == 100) {
				Console.WriteLine ("NPC: In love.");
				if (items.Count > 0) {	
					item = items [x]; 				//Return first item in list
					items.Remove(items[x]);				//Remove first item from list
					x--;
				} else
					item = "";
				return;
			} else if (mood >= 80 && mood < 100) {
				Console.WriteLine ("NPC: Very happy.");

			} else if (mood >= 60 && mood < 80) {
				Console.WriteLine ("NPC: Happy.");

			} else if (mood >= 40 && mood < 60) {
				Console.WriteLine ("NPC: Neutral.");

			} else if (mood >= 20 && mood < 40) {
				Console.WriteLine ("NPC: Negative.");

			} else if (mood < 20) {
				Console.WriteLine ("NPC: Very negative.");
			}
			item = "";
		}
	}
}

