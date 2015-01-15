using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using GitHubby.Models;
using Newtonsoft.Json;

namespace GitHubby
{
    public class WebFetcher
    {
        private const string BaseUrl = "https://api.github.com";

        public Repo[] FetchRepos(string user)
        {
            var client = new HttpClient { BaseAddress = new Uri(BaseUrl) };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "TestApp");

            HttpResponseMessage response = client.GetAsync(String.Format("users/{0}/repos", user)).Result;
            var repoJson = response.Content.ReadAsStringAsync().Result;
            var repos = JsonConvert.DeserializeObject<Repo[]>(repoJson);

            return repos;
        }

        public Repo FetchRepoDetails(string user, string repoName)
        {
           var repos = FetchRepos(user);

            var repoTemp = from repo in repos
                where repo.name == repoName
                select repo;

            var enumerable = repoTemp as Repo[] ?? repoTemp.ToArray();
           
            if (enumerable.Any())
            {
                return enumerable.First();
            }

            return null;
        }

    }
}