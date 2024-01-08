using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphical_Programming_Language
{
    public class CommandParser
    {
        public string CommandName { get; private set; }
        public List<string> Parameters { get; private set; }
        public List<string> DeclaredVariables { get; private set; }

        public CommandParser(string input)
        {
            Parameters = new List<string>();
            /*DeclaredVariables = new List<string>();*/
            ParseInput(input);
        }

        public void ParseInput(string input)
        {
            string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
            {
                throw new ArgumentException("No command provided.");
            }

            CommandName = words[0].ToLower();

            for (int i = 1; i < words.Length; i++)
            {
                Parameters.Add(words[i]);
            }


        }
    }
}