using System;

namespace GitHubby
{
    /// <summary>
    /// Small utility class to collect all the useful IO functionality into one place.
    /// </summary>
    public static class IOUtilities
    {
        /// <summary>
        /// Prompts the user using a message and returns their response as a string.
        /// </summary>
        /// <param name="message">The message to prompt the user with.</param>
        /// <returns>The user's response as a string.</returns>
        public static string PromptUserForString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        /// <summary>
        /// Prompts the user using a message and returns their response as an integer.
        /// </summary>
        /// <param name="message">The message to prompt the user with.</param>
        /// <returns>The user's response as an integer.</returns>
        /// <remarks>This method will loop until the user provides a valid integer response.</remarks>
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

        /// <summary>
        /// Provides the user with the information on how to use this program.
        /// </summary>
        public static void PrintHelp()
        {
            //TODO: Help Text!
            Console.WriteLine("This should be help text");
        }
    }
}