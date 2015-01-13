using System;
using System.Net.Http;
using System.Net.Http.Headers;
using GitHubby.Models;
using Newtonsoft.Json;

namespace GitHubby
{
    public class WebFetcher
    {
        public void Fetch()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.github.com");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "TestApp");

            HttpResponseMessage response = client.GetAsync("users/joefroh/repos").Result;
            var repoJson = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<Repo[]>(repoJson);
        }
    }
}