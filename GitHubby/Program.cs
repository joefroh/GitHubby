using System;
using System.Collections.Generic;
using System.Linq;

namespace GitHubby
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (!args.Any())
            {
                IOUtilities.PrintHelp();
            }
            else
            {
                Dictionary<string, List<string>> commands = CommandLineParser.ParseArguments(args);

                foreach (var command in commands)
                {
                    Actions.ActionSwitch(command);
                }
            }
        }
    }
}