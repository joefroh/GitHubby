using System;

namespace GitHubby
{
    public static class IOUtilities
    {
        public static string PromptUserForString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static int PromptUserForInt(string message)
        {
            int result = 0;
            bool goodInput = false;
            while (!goodInput)
            {
                Console.WriteLine(message);
                var response = Console.ReadLine();

                if (!int.TryParse(response, out result))
                {
                    Console.WriteLine("Please provide a whole number.");
                    continue;
                }
                goodInput = true;
            }

            return result;
        }

        public static void PrintHelp()
        {
            //TODO: Help Text!
            Console.WriteLine("This should be help text");
        }
    }
}