using System;

namespace Player
{
	public class Make : Player
	{
        public Make(string name, int likability, double money, int drunkLevel, int funLevel) : 
            base (name, likability,  money, drunkLevel, funLevel)
        {

        }

        override public void Think()
		{
			Console.WriteLine ("I am Make.");
		}
	}
}

