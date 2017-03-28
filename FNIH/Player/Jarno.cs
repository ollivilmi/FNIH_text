﻿using System;

namespace Player
{
	public class Jarno : Player
	{
        public Jarno(string name,  int likability, double money, int drunkLevel, int funLevel) : 
            base (name, likability,  money, drunkLevel, funLevel)
        {
            hour = 17;
            minute = 0;
        }

		override public void Think()
		{
			Console.WriteLine ("I am Jarno.");
		}

        override public void PlayGuitar()
        {
            Console.WriteLine("Playing guitar.");
            useMoney(5);
            haveFun(5);
        }
	}
}

