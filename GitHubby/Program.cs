using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubby
{
    class Program
    {
        static void Main(string[] args)
        {
            var userID = IOUtilities.PromptUserForInput("Which user would you like to search?");

            var fetch = new WebFetcher();
            fetch.FetchRepos(userID);
            Console.ReadKey();
        }
    }
}
