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
        /// <summary>
        /// This command proceses the input string to obtain command name and parameters
        /// </summary>
        /// <param name="input">Input string to be used</param>
        /// <exception cref="ArgumentException">Throws when command is not provided</exception>
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
            // Validates the parsed command and param.
            ValidateCommandAndParameters();
        }
        /// <summary>
        /// This method combines isvalidcommand method and isvalidparamter method and throws arguments
        /// if the command or parameters are valid.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// This methods have included all the commands available for this program
        /// </summary>
        /// <param name="command">Commands available</param>
        /// <returns></returns>
        public bool IsValidCommand(string command)
        {
            return command == "moveto" || command == "run" || command =="drawto" || command == "clear"
                || command == "reset" || command == "circle" || command == "triangle" || command =="fill" || command == "rectangle" || command == "pen";
        }

        /// <summary>
        /// This method checks for valid parameters only allows ints and 3 colours.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
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
