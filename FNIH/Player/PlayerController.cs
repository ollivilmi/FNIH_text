using System;
using System.Collections.Generic;

namespace Player
{
	public class PlayerController
	{
		public int drunkLevel { get; set; }
		protected int likability;
		protected int funLevel;
		public double money { get; set; }
		public List<string> items { get; set; }
		public string name { get; set; }

			

		public PlayerController (string name)
		{
			
			this.name = name;
			switch (name) {
			case "Jarno":
				this.drunkLevel = 0;
				this.likability = 100;
				this.money = 50;
				this.funLevel = 25;
				break;
			case "Make":
				this.drunkLevel = 30;
				this.likability = 66;
				this.money = 200;
				this.funLevel = 0;
				break;
			case "Placeholder":
				this.drunkLevel = 0;
				this.likability = 33;
				this.money = 1000;
				this.funLevel = -20;
				break;
			}

			this.items = new List<string> ();
		}

		public void dropWallet() {
			this.money = 0;
	}
			
		public void haveFun(int fun) {
			funLevel += fun+(int)drunkFun();		//Have fun increases fun level and takes drunkLevel into
			if (funLevel > 50) {					//consideration as well
				funLevel = 50;
			} else if (funLevel < -50) {
				funLevel = -50;
			}
		}
			
		public void drink(int amount) {
			drunkLevel += amount;
			if (drunkLevel > 100) {  //Drink is used to set your drunkLevel 0-100
				drunkLevel = 100;
				Console.WriteLine ("Drunk level 100: this would lose you the game.");
			}
			if (drunkLevel < 0) {
				drunkLevel = 0;
			}
		}
			

		public int getfunLevel() {
			return funLevel;
		}

		public double drunkFun() {
			return 0.1 * (double)drunkLevel; //A simple math equation used in fun calculation
		}

		public bool useMoney(double sum) { //Used to spend and gain money
			if ((money+sum) >= 0) {			//When sum is negative spend money and vice versa 
				money += sum;				//If sum is more than you can spend, return false
				return true;
			} else
				return false;
		}

		public int getLikability() {
			return likability - (drunkLevel/3); //Return likability, which is affected by drunkLevel
			}

		public void AddItem(string item) {
			items.Add (item);
		}
		public void PrintItems() {
			Console.WriteLine ("Your items:");
			foreach (string item in items) {
				Console.Write (item +", ");
			}
			Console.WriteLine ();
		}

		public void Think() {
			switch (this.name) {
			case "Jarno":
				Jarno.Think ();
				break;
			case "Make":
				Make.Think ();
				break;
			case "Placeholder":
				Placeholder.Think ();
				break;
			}
		}
	}
}

