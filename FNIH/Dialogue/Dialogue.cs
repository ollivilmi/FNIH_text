using System;

namespace Dialogue
{
	public class Dialogue
	{
		private string[] dialogue1, dialogue2Positive, dialogue2Neutral,
		dialogue2Negative, dialogue3Positive, dialogue3Neutral, dialogue3Negative;
		private string[][] dialogue2, dialogue3;
		private Random random;
		private string[] answers;
		private int select;
		public Dialogue ()
		{
			this.dialogue1 = new string[] { "Hey.", "Hello.", "Greetings.", "Yes?", "Sup." };
			this.dialogue2Positive = new string[] {
				"Haha.", 
				"Great.", 
				"Indeed, haha.", 
				"I like how you think."};
			this.dialogue2Neutral = new string[] { 
				"The weather is ok I guess.", 
				"It's been a very usual friday so far.",
				"I guess there's nothing special going on tonight.",
				"I'm bored.",
				"Mmhh.."};
			this.dialogue2Negative = new string[] {
				"What's wrong with you?",
				"Did you come here to fight?", 
				"Are you always this annoying?", 
				"Do you hate the sun?"};
			this.dialogue3Positive = new string[] { 
				"It was fun talking to you.", 
				"I hope I run into you again.", 
				"Have a nice day.", 
				"It was nice to meet you."};
			this.dialogue3Neutral = new string[] { 
				"I guess we're done here.", 
				"That's all.", 
				"Ooookay..", 
				"See you." };
			this.dialogue3Negative = new string[] { 
				"Get the hell out of my face.", 
				"One more word and you are done.", 
				"Are you kidding me?", 
				"That was the last straw." };
			this.dialogue2 = new string[][] { dialogue2Positive, dialogue2Neutral, dialogue2Negative };
			this.dialogue3 = new string[][] { dialogue3Positive, dialogue3Neutral, dialogue3Negative };
			this.random = new Random ();
			this.answers = new string[3];
			this.select = 0;
		}

		public Dialogue (string[] dialogue1, string[][] dialogue2, string[][] dialogue3)
		{
			this.dialogue1 = dialogue1;
			this.dialogue2 = dialogue2; 
			this.dialogue3 = dialogue3;
			this.random = new Random ();
		}

		public string[] randomSelection() { //Used to generate random answer options for array answers[3]
			for (int i = 0; i < 3; i++)
			{
				select = random.Next (1, 4); //Random number 1-3
					switch (select) 
					{
						case 1:
						answers[i] = DialoguePositive.getDialogue();  //Print answer and return that answers[i] = Positive
						break;
						case 2: 
						answers[i] = DialogueNeutral.getDialogue(); //Print answer and return that answers[i] = Neutral
						break;
						case 3: 
						answers[i] = DialogueNegative.getDialogue(); //Print answer and return that answers[i] = Negative
						break;
					}
			}
			return answers; //Return answers[3], which contains strings (Positive, Neutral, Negative)
		}

		public string[] startDialogue1()
		{
			Console.WriteLine ();
			Console.WriteLine (dialogue1 [random.Next (0, dialogue1.Length)]+"\n");
			return randomSelection (); //Print random answers and return answers[3]
		}

		public string[] startDialogue2(int reply) //Parameter reply uses user input 1-3
		{
			Console.WriteLine ();
			switch (reply) {
			case 1:
				Console.WriteLine (dialogue2Positive [random.Next (0, dialogue2Positive.Length)]+"\n"); //If the reply was positive
				return randomSelection ();
			case 2:
				Console.WriteLine (dialogue2Neutral [random.Next (0, dialogue2Neutral.Length)]+"\n"); //If the reply was neutral
				return randomSelection ();
			case 3:
				Console.WriteLine (dialogue2Negative [random.Next (0, dialogue2Negative.Length)]+"\n"); //If the reply was negative
				return randomSelection ();
			default:
				return answers;
			}
		}

		public string[] startDialogue3(int reply)
		{
			Console.WriteLine ();
			switch (reply) {
			case 1:
				Console.WriteLine (dialogue3Positive [random.Next (0, dialogue3Positive.Length)]+"\n"); //If the reply was positive
				return randomSelection ();
			case 2:
				Console.WriteLine (dialogue3Neutral [random.Next (0, dialogue3Neutral.Length)]+"\n"); //If the reply was neutral
				return randomSelection ();
			case 3:
				Console.WriteLine (dialogue3Negative [random.Next (0, dialogue3Negative.Length)]+"\n"); //If the reply was negative
				return randomSelection ();
			default:
				return answers;
			}
		}
	}
}

