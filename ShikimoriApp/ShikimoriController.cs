using ShikimoriApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShikimoriApp
{
    /// 
    /// api/animes
    /// 
    class ShikimoriController
    {
        private const string URL = "https://shikimori.one/";
        private HttpClient httpClient;

        public ShikimoriController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(URL);
        }

        public List<Anime>? GetAnimes()
        {
            // season
            // page
            string param = "api/animes?limit=50&page=1&order=ranked";
            List<Anime> animes = new List<Anime>();
            HttpResponseMessage response = httpClient.GetAsync(param).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                animes = JsonSerializer.Deserialize<List<Anime>>(json); 
            }

            return animes;
        }
    }
}
