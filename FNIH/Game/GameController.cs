using System;
using Dialogue;
using Gambling;
using NPC;
using System.Collections.Generic;

namespace Game
{
	public class GameController
	{
		private BarNPC npc;
		private Player player;
		private GameEvents events;
		private DialogueController dialogue;
		private bool playing;
		private double amount;
		private string input, command;
		private Dictionary<string,string> commands;
		private BouncerDialogue bDialogue;

		public GameController ()
		{
			this.playing = true;
			this.dialogue = new DialogueController ();
			this.player = new Player (70, 0, 187.50, 0); //Likability, drunkLevel, money, funLevel
			this.npc = new BarNPC();
			this.events = new GameEvents (18, 00, player); //Time X hours, X minutes, player
			this.commands = Commands.GetCommands();
			bDialogue = new BouncerDialogue ();

			while (playing == true) {
				Console.WriteLine ("\nDrunk: {0}, Fun: {1}, Money: {2}, Likability: {5} \nScore: {6} Time: {3}:{4}", 
					player.drunkLevel, player.getfunLevel(), player.money, events.hour, events.minute, 
					player.getLikability(), events.score); //Print stats on console
	
				Console.WriteLine ("\nWhat do you want to do: ");
				input = (Console.ReadLine ());

				while (commands.TryGetValue(input, out command) == false) {
					Console.WriteLine ("Invalid argument\n");
					Console.WriteLine ("What do you want to do:"); //Checks that user input is correct
					input = Console.ReadLine ();
				}
				command = input;

				switch (commands[command]) {
				case "drink":
					Console.WriteLine ("How much (number): ");
					input = Console.ReadLine ();
					while (double.TryParse (input, out amount) == false) {
						Console.WriteLine ("Use a number:");   				//Make sure user inputs a number
						input = Console.ReadLine ();
					}
					if (player.useMoney (-amount * 7.50) == false) {	 //Drinking one beer takes 10 minutes
						Console.WriteLine ("Not enough money");	  		//Price of one beer is 7,50
						break;
					}
					player.drink ((int)(10 * amount)); 
					events.changeTime (10 * (int)amount);
					break;
				case "dialogue":
					npc.changeMood (dialogue.startDialogue (player.getLikability ())); //Start dialogue
					string item;
					npc.ReturnItems (out item);
					if (item.Length > 0) {
						Console.WriteLine ("You received: " +item);
						player.AddItem (item);
					}
					player.PrintItems ();
					events.changeTime (15);												//Dialogue takes 15 minutes
					player.haveFun (10);									//+Fun depending on your mood
					events.addScore(10);
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
					amount = Convert.ToDouble (Console.ReadLine ());
					if (player.useMoney (-amount) == false) {                                       
						Console.WriteLine ("Not enough money");	  		 				
						break;	
					}											//Throw a coin to double your money or lose it						
					amount = CoinToss.gamble (amount);
					if (amount > 0) {
						player.haveFun (10);
						player.money += amount;
					} else {
						player.haveFun (-5);
					}
					events.changeTime (10);
					break;
				case "help":
					Console.WriteLine ("You can drink, start a dialogue, gamble," +
					" change time, spend money or quit.");
					break;
				case "inventory":
					player.PrintItems ();
					break;
				case "bar":
					if (bDialogue.bouncerDialogue ()) {
						player.useMoney (-5);
					}
					break;
				default:
					Console.WriteLine ("Invalid command");
					break;
				}
			}
		}
	}
}
