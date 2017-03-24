using System;

namespace Game
{
	public class GameEvents
	{
		public int score { get; set; }
		public int hour { get; set; }
		public int minute { get; set; }
		private Player player;
		public GameEvents (int hour, int minute, Player player)
		{
			this.hour = hour;
			this.minute = minute;
			this.player = player;
		}

		public void addScore (int score) {
			this.score += (int)(score+(0.1 * (double)player.funLevel)); //Add score, bonus points for funLevel
		}

		public void changeTime (int minute) {
			this.minute += minute;
			while (this.minute >= 60 || this.hour == 24) {
				if (this.minute >= 60) { 
					this.minute -= 60;			//Every time a hour passes
					this.hour++;				// Have some fun if you are drunk
					player.haveFun (0);			
					this.score += player.funLevel;
				}
				if (this.hour == 24) {
					this.hour = 0;
				}
				player.drink (-(int)((double) minute * 1/6)); //Drunk level decreases by the amount of minutes passed
			}												//!Note! If only 5 minutes passes it doesnt decrease.
		}			
	}
}

