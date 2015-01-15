using System;
using System.Collections.Generic;
using System.Linq;
using GitHubby.Models;

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
                    //User Repo Link Search
                case "-url":
                    if (command.Value.Count == 1)
                    {
                        UserRepoLink(command.Value.First());
                    }
                    else
                    {
                        throw new ArgumentException("User Repo Search (-url) takes one parameter.");
                    }
                    break;
                default:
                    //TODO: Alert the user to an unrecognized command.
                    Console.WriteLine("Unrecognized Command {0}", command.Key);
                    break;
            }
        }

        private static void UserRepoSearch(string userId)
        {
            var fetch = new WebFetcher();
            Repo[] repos = fetch.FetchRepos(userId);

            foreach (Repo repo in repos)
            {
                Console.WriteLine(repo.name);
            }
        }

        private static void UserRepoLink(string repoName)
        {
            var fetch = new WebFetcher();
            string[] repoTokens = repoName.Split('/');

            //Should be in the form User/Repo
            if (repoTokens.Count() != 2)
            {
                throw new ArgumentException("Repo Name must be in the form <user>/<repo>.");
            }
            Repo repo = fetch.FetchRepoDetails(repoTokens[0], repoTokens[1]);

            if (repo == null)
            {
                Console.WriteLine("Could not find repo {0}", repoName);
            }
            else
            {
                Console.WriteLine(repo.git_url);
            }
        }
    }
}