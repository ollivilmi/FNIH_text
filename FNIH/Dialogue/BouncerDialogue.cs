using System;
using Game;

namespace Dialogue
{
	public class BouncerDialogue
	{
		private string sInput;
		private int input;

		public BouncerDialogue ()
		{ 
		}

		public Boolean bouncerDialogue ()
		{ 

			//could add some randomized dialogue options
			Console.WriteLine ("Bouncer - Good evening");
			Console.WriteLine ("Actions: \n(1)Buy ticket\n(2)Leave\n");
			sInput = Console.ReadLine (); 
			while (int.TryParse (sInput, out input) == false || input > 2 || input < 0) { 
				Console.Write ("Use integer (1-2): ");   //Make sure user inputs an integer 1-3 
				sInput = (Console.ReadLine ()); 

			}
			switch (input) { 
			case 1: //1st switch

				Console.WriteLine ("You - I'd like to buy a ticket"); 
				Console.WriteLine ("Bouncer - That would be 5$.");
				Console.Write ("Actions: \n(1)Pay 5$\n(2)Don't enter bar\n"); 
				sInput = Console.ReadLine (); 
				while (int.TryParse (sInput, out input) == false || input > 2 || input < 0) { 
					Console.Write ("Use integer (1-2): ");   //Make sure user inputs an integer 1-3 
					sInput = (Console.ReadLine ());
				} 

				//add if money >= 5 

				switch (input) { 
				case 1: //2nd switch
					Console.WriteLine ("(1)Enter bar\n(2)Don't enter");
					sInput = Console.ReadLine (); 
					while (int.TryParse (sInput, out input) == false || input > 2 || input < 0) { 
						Console.Write ("Use integer (1-2): ");   //Make sure user inputs an integer 1-3 
						sInput = (Console.ReadLine ()); 

					}
					switch (input) {
					case 1: //3rd switch
						Console.WriteLine ("You are now in the bar"); 
						return true;
					case 2: //3rd switch
						Console.WriteLine ("You now have a ticket"); 
						return true;
					default:
						return false;
					}

				case 2: //2nd switch
					Console.WriteLine ("You did not enter the bar"); 
					return false; 
				default:
					return false;
				}

			case 2: //1st switch 
				
				Console.WriteLine ("Bouncer - See you."); 
				return false;

			default:
				return false;
			} 
		}

	}
}
