using System;

namespace Player
{
	public class Placeholder : Player
	{
        public Placeholder(string name, int likability, double money, int drunkLevel, int funLevel) : 
            base (name, likability,  money, drunkLevel, funLevel)
        {

        }

        override public void Think()
		{
			Console.WriteLine ("I am Placeholder.");
		}

        public override void PlayGuitar()
        {
            Console.WriteLine("I have no idea how.");
        }
    }
}

