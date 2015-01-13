using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace GitHubby
{
    public class WebFetcher
    {

        public WebFetcher()
        {

        }

        public void Fetch()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress= new Uri("https://api.github.com");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "TestApp");
            
            HttpResponseMessage response = client.GetAsync("").Result;
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);

        }
    }
}
