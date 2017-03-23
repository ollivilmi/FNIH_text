using System;

namespace FNIH
{
	public class Game
	{
		Player player;
		GameEvents events;
		DialogueController dialogue;
		private bool playing;
		private double amount;
		private string input;

		public Game ()
		{
			this.playing = true;
			this.dialogue = new DialogueController ();
			this.player = new Player (70, 0, 187.50, 0); //Likability, drunkLevel, money, funLevel
			this.events = new GameEvents (18, 00, player); //Time X hours, X minutes, player

			while (playing == true) {
				Console.WriteLine ("\nDrunk: {0}, Fun: {1}, Money: {2}, Time: {3}:{4} Likability: {5} Mood: {6}", 
					player.drunkLevel, player.funLevel, player.money, events.hour, events.minute, 
					player.getLikability(), player.getMood()); //Print stats on console
				Console.WriteLine ("What do you want to do:\n");
				input = Console.ReadLine ();
				switch (input) {
				case "drink":
					Console.WriteLine ("How much: ");
					amount = Convert.ToDouble (Console.ReadLine ()); //How much means how many beers
					player.drink ((int)(10 * amount));              
					events.changeTime (10 * (int)amount);			//Drinking one beer takes 10 minutes 
					player.useMoney (-(amount * 7.5));				//Price of one beer is 7,50
					break;
				case "dialogue":
					player.changeMood (dialogue.startDialogue (player.getLikability ())); //Start dialogue
					events.changeTime (15);												//Dialogue takes 15 minutes
					player.haveFun (player.getMood());									//+Fun depending on your mood
					break;
				case "spend":
					Console.WriteLine ("How much: ");						//Throw away cash
					amount = Convert.ToDouble(Console.ReadLine ());			//If you spend "-x" you gain money
					player.useMoney (-amount);
					break;
				case "quit":
					playing = false;				//Quit the game
					break;
				case "changeTime":
					Console.WriteLine ("How many minutes: ");					//Skip time
					amount = Convert.ToDouble(Console.ReadLine ());
					events.changeTime ((int)amount);
					break;
				case "gamble":
					Console.WriteLine ("How much: ");
					amount = Convert.ToDouble (Console.ReadLine ()); //Throw a coin to double your money or lose
					player.useMoney (-amount);						//everything
					amount = CoinToss.gamble (amount);
					if (amount > 0) {
						player.haveFun (10);
						player.useMoney (amount);
					} else {
						player.haveFun (-5);
					}
					events.changeTime (10);
					break;
				default:
					Console.WriteLine ("Invalid command");
					break;
				}
			}
		}
	}
}
