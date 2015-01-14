using System;
using System.Collections.Generic;
using System.Linq;

namespace GitHubby
{
    public static class CommandLineParser
    {

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