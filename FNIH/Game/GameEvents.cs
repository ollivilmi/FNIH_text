using System;
using Player;

namespace Game
{
	public class GameEvents
	{
		public int score { get; set; }
		public int hour { get; set; }
		public int minute { get; set; }
		private PlayerController player;
		public GameEvents (int hour, int minute, PlayerController player)
		{
			this.hour = hour;
			this.minute = minute;
			this.player = player;
		}

		public void addScore (int score) {
			this.score += (int)(score+(0.1 * (double)player.getfunLevel())); //Add score, bonus points for funLevel
		}

		public void changeTime (int minute) {
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
	}
}

