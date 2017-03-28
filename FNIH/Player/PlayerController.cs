using System;
using System.Collections.Generic;

namespace Player
{
	public class PlayerController
	{
        private string name;
        private Jarno char1;
        private Make char2;
        private Placeholder char3;

		public PlayerController (string name)
		{
			
			this.name = name;
			switch (name) {
			case "Jarno":
                    this.char1 = new Jarno("Jarno", 100, 50, 0, 20);
				break;
			case "Make":
                    this.char2 = new Make("Make",66, 200, 30, 0);
				break;
			case "Placeholder":
                    this.char3 = new Placeholder("Placeholder",33, 1000, 0, -20);
				break;
			}
		}

        public Player GetCharacter()
        {
            switch (name)
            {
                case "Jarno":
                    return char1;
                case "Make":
                    return char2;
                case "Placeholder":
                    return char3;
                default:
                    return char1;
            }
        }
	}
}

