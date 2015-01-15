using System;
using System.Collections.Generic;
using System.Linq;

namespace GitHubby
{
    /// <summary>
    /// Small utility class to parse the command line input to the program.
    /// </summary>
    public static class CommandLineParser
    {
        /// <summary>
        /// Parses the arguments provided through the command line of the form "-command [parameter(s)]".
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        /// <returns>A Dictionary containing the command line arguments with the -commands as keys and their parameters in a list of strings as the value.</returns>
        public static Dictionary<string, List<string>> ParseArguments(string[] args)
        {
            var arguments = new Dictionary<string, List<string>>();
            var command = "";

            foreach (var token in args)
            {
                if (token.First() != '-')
                {
                    if (String.IsNullOrEmpty(command))
                    {
                        throw new ArgumentException("You must provide at least one command starting with a '-'.");
                    }
                    
                    arguments[command].Add(token);
                }
                else
                {
                    command = token;

                    if (!arguments.ContainsKey(command))
                    {
                        arguments[command] = new List<string>();
                    }
                    else
                    {
                        throw new ArgumentException(String.Format("Error Duplicate Command: {0}",command));
                    }
                }
            }
            return arguments;
        } 

    }
}