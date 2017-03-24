using System;

namespace Game
{
	public class Player
	{
		public int drunkLevel { get; set; }
		private int likability;
		private int mood;
		public double money { get; set; }
		public int funLevel { get; set; }
		private bool wallet;
			

		public Player (int likability, int drunkLevel, double money, int funLevel)
		{
			this.wallet = true;
			this.drunkLevel = drunkLevel;
			this.likability = likability;
			this.money = money;
			this.funLevel = funLevel;
			this.mood = 0;
		}

		public void dropWallet() {
			wallet = false;
			this.money = 0;
	}
			
		public void haveFun(int fun) {
			funLevel += fun+(int)drunkFun();		//Have fun increases fun level and takes drunkLevel into
			if (funLevel >= 100) {					//consideration as well
				funLevel = 100;
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

	}
}

