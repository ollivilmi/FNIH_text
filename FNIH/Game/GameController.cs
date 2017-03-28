using System;
using Dialogue;
using Gambling;
using NPC;
using Player;
using System.Collections.Generic;

namespace Game
{
	public class GameController
	{
		private BarNPC barNPC;
		private CharacterSelection selection;
		private GameEvents events;
		private DialogueController dialogue;
		private bool playing;
		private double amount;
        private string command, name;
		private Dictionary<string,string> commands;
		private BouncerNPC bouncer;
        private PlayerController playerCreation;
        private Player.Player player;

		public GameController ()
		{
			this.selection = new CharacterSelection (); //Prints character selection menu
			this.name = selection.StartSelection ();   //Returns name of the character that was chosen
			this.playing = true;                        
			this.dialogue = new DialogueController ();
			this.playerCreation = new PlayerController (name); //Creates player character
            this.player = playerCreation.GetCharacter(); //Sets player as the character that was chosen
			this.barNPC = new BarNPC();
			this.events = new GameEvents (player); //Time X hours, X minutes, player
			this.commands = Commands.GetCommands();
			this.bouncer = new BouncerNPC (player);

			while (playing == true) {
                events.PrintStats();                                //Prints stats
				Console.WriteLine ("\nWhat do you want to do: ");
                command = events.GetStringInput(commands);           //Get a command string

				switch (commands[command]) {
				case "drink":
					Console.WriteLine ("How much (number): ");
                    amount = events.GetDoubleInput(); 
                    events.Drink(amount);     //Drink amount if you can afford it
					break;
				case "dialogue":
                    events.BarDialogue(barNPC, dialogue); //Start dialogue with bar NPC
					break;
				case "spend":
                    events.UseMoney(); //Throw away money
					break;
				case "quit":
					playing = false;	   //Quit the game
					break;
				case "change time":
					Console.WriteLine ("How many minutes: ");       //Skip time
                    amount = events.GetDoubleInput();
					events.ChangeTime ((int)amount);
					break;
				case "gamble":
                    events.CoinToss(); //Flip a coin to double or lose your money
					break;
				case "help":
					Console.WriteLine ("You can go to the bar, drink, start a dialogue, gamble," +
					" change time, spend money, play guitar, check your items, think or quit.");
					break;
				case "inventory":
					player.PrintItems ();
					break;
				case "bar":
                    events.GoToBar(bouncer);
					break;
				case "think":
					player.Think ();
					break;
                case "guitar":
                    player.PlayGuitar();
                    break;
				default:
					Console.WriteLine ("Invalid command");
					break;
				}
			}
		}
	}
}
