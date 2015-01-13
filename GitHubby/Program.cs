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
            PrintMenu();
            Console.ReadKey();
        }

        public static void PrintMenu()
        {
            Console.WriteLine("1. User Repo Search");
           
            var response = IOUtilities.PromptUserForInt("What would you like to do? (pick a number)");

            switch (response)
            {
                case 1:
                    Actions.UserRepoQuery();
                    break;
                default:
                    break;
            }
        }
    }
}
