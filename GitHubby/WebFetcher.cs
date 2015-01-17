using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using GitHubby.Models;
using Newtonsoft.Json;

namespace GitHubby
{
    /// <summary>
    ///     Class that makes the API calls and provides deserialized classes from the responses.
    /// </summary>
    public class WebFetcher
    {
        //The base URL of the GitHub api
        private const string BaseUrl = "https://api.github.com";

        /// <summary>
        ///     Using a web API call, fetches all of the repositories for a given user.
        /// </summary>
        /// <param name="user">The user whose repositories we are after.</param>
        /// <returns>The repositories the user owns.</returns>
        public Repo[] FetchRepos(string user)
        {
            using (var client = new HttpClient {BaseAddress = new Uri(BaseUrl)})
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "TestApp");

                HttpResponseMessage response = client.GetAsync(String.Format("users/{0}/repos", user)).Result;

                if (response.IsSuccessStatusCode)
                {
                    string repoJson = response.Content.ReadAsStringAsync().Result;
                    var repos = JsonConvert.DeserializeObject<Repo[]>(repoJson);

                    return repos;
                }
                return new Repo[] {};
            }
        }

        /// <summary>
        ///     Using a web API call, fetches the given repository.
        /// </summary>
        /// <param name="user">The user who owns the repo.</param>
        /// <param name="repoName">The name of the repo.</param>
        /// <returns>The repository.</returns>
        public Repo FetchRepoGitLink(string user, string repoName)
        {
            Repo[] repos = FetchRepos(user);

            IEnumerable<Repo> repoTemp = from repo in repos
                where repo.name == repoName
                select repo;

            Repo[] enumerable = repoTemp as Repo[] ?? repoTemp.ToArray();

            if (enumerable.Any())
            {
                return enumerable.First();
            }

            return null;
        }
    }
}