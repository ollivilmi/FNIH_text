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
            { "spend", "spend" },
			{ "stop", "quit" },
			{ "exit", "quit" },
			{ "leave", "quit" },
			{ "end", "quit" },
			{ "quit", "quit" },
			{ "die", "quit" },
			{ "change time", "change time" },
			{ "set time", "change time" },
			{ "forward time", "change time" },
			{ "fast forward", "change time" },
			{ "time skip", "change time" },
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
			{ "equipment", "inventory" },
			{ "bar", "bar" },
			{ "enter bar", "bar" },
			{ "go to bar", "bar" },
			{ "pub", "bar" },
			{ "think", "think"},
			{ "thoughts", "think" },
            { "guitar", "guitar" },
            { "play guitar", "guitar" },
            { "music", "guitar" }
		};

		public static Dictionary<string,string> GetCommands()
		{
			return synonyms;
		}
	}
}

