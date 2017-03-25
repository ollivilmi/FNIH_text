using System;

namespace Dialogue
{
	public class DialogueController
	{
		private Dialogue dialogue;
		private int level, input, reply, mood;
		private string[] answers;
		private string sInput;
		bool check;

		public DialogueController ()
		{
			this.level = 1;
			this.input = 0; 
			this.reply = 0; 
			this.mood = 0;
			this.answers = new string[3];
			this.dialogue = new Dialogue ();
			this.check = false;
		}
		/// <summary>
		/// Starts the dialogue.
		/// </summary>
		/// <returns>The dialogue.</returns>
		/// <param name="likability">Likability.</param>
		public int startDialogue (int likability)
		{
			while (level < 4) {
				switch (level) { //Switch to progress conversation 
				case 1:
					answers = dialogue.startDialogue1 (); //Conversation level 1
					break;

				case 2:
					answers = dialogue.startDialogue2 (reply); //Conversation level 2
					break;

				case 3:
					answers = dialogue.startDialogue3 (reply); //Conversation level 3
					break;

				default:  //"Level 4", at the moment means conversation is done
					Console.WriteLine ("CONVERSATION FINISHED: mood change: {0}\n\n\n", mood);	//Restarts																
					break;
				}
				if (level == 4) {
					break;
				}
				Console.Write ("(1-3): ");
				sInput = Console.ReadLine ();
				check = int.TryParse (sInput, out input);
				while (check == false || input > 3 || input < 0) {
					Console.WriteLine ("Use an integer (1-3):");   //Make sure user inputs an integer 1-3
					sInput = (Console.ReadLine ());
					check = int.TryParse (sInput, out input);
				}
				input--; 
				//Use user input (answers[0-2])

				switch (answers [input]) {							//Randomized answers return an array of answers[3], which contains
				case "Positive":								    //answers[0] Positive, answers[1] Neutral, answers[2] Negative
					Console.Write ("(positive)\n\n");			    
					level++;                                   		//Level++ takes the conversation to the next level	
					reply = 1;										// and reply is used as a parameter to define
					mood += ((int)(0.4*(double)likability)); 		// a Positive, Neutral or Negative response
					break;
				case "Neutral":
					Console.Write ("(neutral)\n\n");
					level++;
					reply = 2;
					mood += ((int)(0.1*(double)likability));
					break;
				case "Negative":
					Console.Write ("(negative)\n\n");
					level++;
					reply = 3;
					mood -= ((int)(0.4*(double)likability));
					break;
				}
			}
			level = 1;
			return mood;
		}
	}
}