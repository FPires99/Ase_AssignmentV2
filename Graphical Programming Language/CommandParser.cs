using System;
using System.Collections.Generic;

namespace Graphical_Programming_Language
{
    public class CommandParser
    {
        public string CommandName { get; private set; }
        public List<string> Parameters { get; private set; }

        public CommandParser(string input)
        {
            Parameters = new List<string>();
            ParseInput(input);
        }

        public void ParseInput(string input)
        {
            string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
            {
                throw new ArgumentException("No command provided.");
            }

            CommandName = words[0].ToLower(); // Convert to lowercase for case-insensitive command matching;

            for (int i = 1; i < words.Length; i++)
            {
                Parameters.Add(words[i]);
            }

            ValidateCommandAndParameters();
        }

        public void ValidateCommandAndParameters()
        {
            if (!IsValidCommand(CommandName))
            {
                throw new ArgumentException("Invalid command: " + CommandName);
            }

            foreach (string param in Parameters)
            {
                if (!IsValidParameter(param))
                {
                    throw new ArgumentException("Invalid parameter: " + param);
                }
            }
        }

        // Method to check for valid commands .
        public bool IsValidCommand(string command)
        {
            return command == "moveto" || command == "run" || command =="drawto" || command == "clear"
                || command == "reset" || command == "circle" || command == "triangle" || command =="fill" || command == "rectangle" || command == "pen";
        }

        // Method to check for valid parameters.
        public bool IsValidParameter(string parameter)
        {
            int result;
            if (int.TryParse(parameter, out result))
            {
                return true;
            }
            string lowerParameter = parameter.ToLower();
            return lowerParameter == "blue" || lowerParameter == "red" || lowerParameter == "green";
        }
    }
}
