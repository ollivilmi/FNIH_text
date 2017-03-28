using System;
using System.Collections.Generic;

namespace Game
{
	public static class Commands
	{
		private static Dictionary<string,string> synonyms = new Dictionary<string,string> {
			{ "drink", "drink" },
			{ "get a drink", "drink" },
			{ "get drunk", "drink" },
			{ "beer", "drink" },
			{ "get wasted", "drink" },
			{ "conversation", "dialogue" },
			{ "converse", "dialogue" },
			{ "talk", "dialogue" },
			{ "chat", "dialogue" },
			{ "speak", "dialogue" },
			{ "dialogue", "dialogue" },
			{ "give money", "spend" },
			{ "throw away money", "spend" },
			{ "spend money", "spend" },
			{ "stop", "quit" },
			{ "exit", "quit" },
			{ "leave", "quit" },
			{ "end", "quit" },
			{ "quit", "quit" },
			{ "die", "quit" },
			{ "change time", "changeTime" },
			{ "set time", "changeTime" },
			{ "forward time", "changeTime" },
			{ "fast forward", "changeTime" },
			{ "time skip", "changeTime" },
			{ "gamble", "gamble" },
			{ "toss coin", "gamble" },
			{ "play", "gamble" },
			{ "bet", "gamble" },
			{ "wager", "gamble" },
			{ "help", "help" },
			{ "what to do", "help" },
			{ "options", "help" },
			{ "?", "help" },
			{ "inventory", "inventory" },
			{ "items", "inventory" },
			{ "stuff", "inventory" },
			{ "equipment", "inventory" }
		};

		public static Dictionary<string,string> GetCommands()
		{
			return synonyms;
		}
	}
}

