using System;
using Player;
using System.Collections.Generic;
using NPC;
using Dialogue;
using Gambling;

namespace Game
{
	public class GameEvents
	{
		public int score { get; set; }
		public int hour { get; set; }
		public int minute { get; set; }
        private string input, output, item;
        private double amount;
		private Player.Player player;
		public GameEvents (Player.Player player)
		{
            this.player = player;
            this.hour = player.hour;
            this.minute = player.minute;	
		}

		public void addScore (int score) {
			this.score += (int)(score+(0.1 * (double)player.getfunLevel())); //Add score, bonus points for funLevel
		}

		public void ChangeTime (int minute) {
			this.minute += minute;
			player.drink (-(int)((double) minute * 1/6)); //Drunk level decreases by the amount of minutes passed
			while (this.minute >= 60 || this.hour == 24) { //!Note! If only 5 minutes passes it doesnt decrease.
				if (this.minute >= 60) { 
					this.minute -= 60;			//Every hour in Africa an hour passes
					this.hour++;				// Have some fun if you are drunk
					player.haveFun (-10);		// Fun level decreases over time	
					score += (player.getfunLevel())/2;
				}
				if (this.hour == 24) {
					this.hour = 0;
				}
			}												
		}

        public void PrintStats()
        {
            Console.WriteLine("\nDrunk: {0}, Fun: {1}, Money: {2}, Likability: {5} \nScore: {6} Time: {3}:{4} Name: {7}",
                    player.drunkLevel, player.getfunLevel(), player.money, this.hour, this.minute,
                    player.getLikability(), this.score, player.name); //Print stats on console
        }

        public string GetStringInput(Dictionary<string, string> commands)
        {
            input = (Console.ReadLine());
            while (commands.TryGetValue(input, out output) == false)
            {
                Console.WriteLine("Invalid argument\n");
                Console.WriteLine("What do you want to do:"); //Checks that user input is correct
                input = Console.ReadLine();
            }
            return output;
        }

        public double GetDoubleInput()
        {
            input = Console.ReadLine();
            while (double.TryParse(input, out amount) == false)
            {
                Console.WriteLine("Use a number:");                 //Make sure user inputs a number
                input = Console.ReadLine();
            }
            return amount;
        }

        public void Drink(double amount)
        {
            if (player.useMoney(-amount * 7.50) == false) //Price of one beer is 7,50
            {                                                   
                Console.WriteLine("Not enough money");          
                return;
            }
            player.drink((int)(10 * amount));            
            this.ChangeTime(10 * (int)amount);  // Drinking one beer takes 10 minutes
        }

        public void BarDialogue(BarNPC npc, DialogueController dialogue)
        {
            npc.changeMood(dialogue.startDialogue(player.getLikability())); //Start dialogue
            npc.ReturnItems(out item);
            if (item.Length > 0)
            {
                Console.WriteLine("You received: " + item);
                player.AddItem(item);
            }
            player.PrintItems();
            this.ChangeTime(15);                                  //Dialogue takes 15 minutes
            player.haveFun(10);                                 //+Fun depending on your mood
            this.addScore(10);
        }

        public void UseMoney()
        {
            Console.WriteLine("How much: ");
            amount = GetDoubleInput();
            player.useMoney(-amount);
        }
        
        public void CoinToss() //Throw a coin to double your money or lose it
        {
            Console.WriteLine("How much: ");
            amount = GetDoubleInput();
            if (player.useMoney(-amount) == false)
            {
                Console.WriteLine("Not enough money");
                return;
            }                                           						
            amount = Gambling.CoinToss.gamble(amount);
            if (amount > 0)
            {
                Console.WriteLine("You won!");
                player.haveFun(10);
                player.money += amount;
            }
            else
            {
                Console.WriteLine("You lost!");
                player.haveFun(-5);
            }
            this.ChangeTime(10);
        }
        
        public void GoToBar(BouncerNPC bouncer)
        {
            if (player.items.Contains("Ticket"))
            {
                Console.WriteLine("You are now in the bar");
            }
            else
            {
                bouncer.StartDialogue(0);
            }
        }		
	}
}

