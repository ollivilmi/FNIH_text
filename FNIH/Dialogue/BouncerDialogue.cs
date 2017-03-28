﻿using System; 
using Game; 

namespace Dialogue 
{ 
	public class BouncerDialogue 
	{ 
		private string sInput; 
		private int input; 
		public BouncerDialogue () 
		{ 
		} 
		public Boolean bouncerDialogue(){ 

			//could add some randomized dialogue options 
			Console.WriteLine ("Bouncer - Good evening");   
			// add if (player has ticket item) 

			Console.WriteLine ("Actions: \n(1)Show ticket\n(2)Buy ticket\n");  
			sInput = Console.ReadLine (); 
			while (int.TryParse (sInput, out input) == false || input > 2 || input < 0) { 
				Console.Write ("Use integer (1-2): ");   //Make sure user inputs an integer 1-3 
				sInput = (Console.ReadLine ()); 

			} 


			switch (input) { 
			case 1: 

				Console.WriteLine ("Bouncer - Thank you sir."); 
				Console.WriteLine ("You are now in the bar"); 
				return false; 


			case 2: 

				Console.WriteLine ("You - I'd like to buy a ticket"); 
				Console.WriteLine ("Bouncer - That would be 5$."); 


				Console.Write ("Actions: \n(1)Pay 5$\n(2)Don't enter bar\n"); 
				sInput = Console.ReadLine (); 
				while (int.TryParse (sInput, out input) == false || input > 2 || input < 0) { 
					Console.Write ("Use integer (1-2): ");   //Make sure user inputs an integer 1-3 
					sInput = (Console.ReadLine ()); 

				} 

				//add if money >= 5 

				switch (input) { 
				case 1: 

					Console.WriteLine ("You are now in the bar"); 
					return true; 

				case 2: 
					Console.WriteLine ("You did not enter the bar"); 
					return false; 

				default: 
					Console.WriteLine ("Wrong command"); 
					Console.WriteLine ("Could not enter the bar"); 
					//add loop in case of wrong command 
					return false; 

				} 
				break; 

			default: 
				Console.WriteLine ("Wrong command"); 
				Console.WriteLine ("Could not enter the bar"); 
				//add loop in case of wrong command 
				return false; 

			} 
		} 

	} 
} 
