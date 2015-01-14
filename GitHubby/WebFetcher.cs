using System;
using System.Net.Http;
using System.Net.Http.Headers;
using GitHubby.Models;
using Newtonsoft.Json;

namespace GitHubby
{
    public class WebFetcher
    {
        private const string BaseUrl = "https://api.github.com";

        public void FetchRepos(string user)
        {
            var client = new HttpClient { BaseAddress = new Uri(BaseUrl) };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "TestApp");

            HttpResponseMessage response = client.GetAsync(String.Format("users/{0}/repos", user)).Result;
            var repoJson = response.Content.ReadAsStringAsync().Result;
            var repos = JsonConvert.DeserializeObject<Repo[]>(repoJson);

            foreach (var repo in repos)
            {
                Console.WriteLine(repo.name);
            }
         }


    }
}