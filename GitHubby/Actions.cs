namespace GitHubby
{
    public static class Actions
    {
        public static void UserRepoQuery()
        {
            var userID = IOUtilities.PromptUserForString("Which user would you like to search?");
            var fetch = new WebFetcher();
            fetch.FetchRepos(userID);
        }
    }
}