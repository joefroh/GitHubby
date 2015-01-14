using System;
using System.Collections.Generic;
using System.Linq;

namespace GitHubby
{
    public static class Actions
    {
        public static void ActionSwitch(KeyValuePair<string, List<string>> command)
        {
            switch (command.Key)
            {
                    //User Repo Search
                case "-urs":
                    if (command.Value.Count == 1)
                    {
                       UserRepoSearch(command.Value.First());
                    }
                    else
                    {
                        throw new ArgumentException("User Repo Search (-urs) takes one parameter.");
                    }
                    break;
                default:
                    //TODO: Alert the user to an unrecognized command.
                    Console.WriteLine(String.Format("Unrecognized Command {0}",command.Key));
                    break;
            }
        }

        private static void UserRepoSearch(string userID)
        {
            var fetch = new WebFetcher();
            fetch.FetchRepos(userID);
        }
    }
}