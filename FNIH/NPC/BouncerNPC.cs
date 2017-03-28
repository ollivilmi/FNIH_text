using System;
using Dialogue;
using Game;
using Player;
using System.Collections.Generic;

namespace NPC
{
	public class BouncerNPC : NPC
	{
		private BouncerDialogue bd;
		private Player.Player player;
		public BouncerNPC (Player.Player player)
		{
			this.player = player;
			mood = random.Next (0, 101);
			items = new List<string>() { "Ticket" };
			bd = new BouncerDialogue ();
		
		}
		override public void StartDialogue(int likability){
			if (bd.bouncerDialogue () && items.Contains("Ticket")) {
				items.Remove ("Ticket");
				player.AddItem ("Ticket");
				player.useMoney (-5);
			}
		}




	}
}

