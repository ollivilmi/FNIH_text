using System;

namespace Player
{
	public class Jarno : Player
	{
        public Jarno(string name,  int likability, double money, int drunkLevel, int funLevel) : 
            base (name, likability,  money, drunkLevel, funLevel)
        {

        }

		override public void Think()
		{
			Console.WriteLine ("I am Jarno.");
		}

        override public void PlayGuitar()
        {
            Console.WriteLine("Playing guitar.");
        }
	}
}

