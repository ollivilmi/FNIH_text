using System;
using System.Collections.Generic;

namespace NPC

{
	public abstract class NPC
	{
		protected int mood;
		protected List<string> items;
		protected Random random = new Random();

		public abstract void StartDialogue(int likability); //Start DialogueController.startDialogue(); or something else

		public void changeMood(int mood) {
			this.mood += mood;
			if (this.mood > 100) {				//changeMood is used to set your mood 0-100
				this.mood = 100;
			}
			if (this.mood < 0) {
				this.mood = 0;
			}
		}

		public int getMood() {
			return this.mood;
		}
	}
}

