using System;

namespace GitHubby
{
    public static class IOUtilities
    {
        public static string PromptUserForInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}