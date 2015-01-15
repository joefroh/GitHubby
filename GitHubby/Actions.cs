using System;
using System.Collections.Generic;
using System.Linq;
using GitHubby.Models;

namespace GitHubby
{
    /// <summary>
    /// Class that contains all the different action methods that correspond to the command line flags.
    /// </summary>
    public static class Actions
    {
        /// <summary>
        /// Entry way to the class, will trigger the correct action for a corresponding command flag.
        /// </summary>
        /// <param name="command">A KeyValuePair containing a string as the key and a list of strings as the value.<br></br>
        /// These correspond to the command line arguments. e.g. "-urs username" would have "-urs" as the key and "username" in a list of values.
        /// </param>
        public static void ActionSwitch(KeyValuePair<string, List<string>> command)
        {
            switch (command.Key)
            {
                    //User Repo Search
                case "-urs":
                    // -urs username
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
                    // -url <username>/<repo>
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

        /// <summary>
        /// Perfoms the action corresponding to the -urs command flag.
        /// Searches for all of the repos owned by a user.
        /// </summary>
        /// <param name="userId">The user whose repos we are searching for.</param>
        private static void UserRepoSearch(string userId)
        {
            var fetch = new WebFetcher();
            Repo[] repos = fetch.FetchRepos(userId);

            foreach (Repo repo in repos)
            {
                Console.WriteLine(repo.name);
            }
        }

        /// <summary>
        /// Performs the action corressponding to the -url command flag.
        /// Searches for a repo by full name and provides the git link.
        /// </summary>
        /// <param name="repoName">The name of the repo being searched for.</param>
        private static void UserRepoLink(string repoName)
        {
            var fetch = new WebFetcher();
            string[] repoTokens = repoName.Split('/');

            //Should be in the form User/Repo
            if (repoTokens.Count() != 2)
            {
                throw new ArgumentException("Repo Name must be in the form <user>/<repo>.");
            }
            Repo repo = fetch.FetchRepoGitLink(repoTokens[0], repoTokens[1]);

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