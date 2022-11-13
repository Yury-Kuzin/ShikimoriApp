using ShikimoriApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace ShikimoriApp
{
    /// 
    /// api/animes
    /// 
    class ShikimoriContext
    {
        private const string URL = "https://shikimori.one/";
        private HttpClient httpClient;

        public ShikimoriContext()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(URL);
        }

        public AnimeInfo? GetAnime(int id)
        {
            string param = $"api/animes/{id}";
            HttpResponseMessage response = httpClient.GetAsync(param).Result;
            AnimeInfo? animeInfo = new AnimeInfo();
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                animeInfo = JsonSerializer.Deserialize<AnimeInfo>(json);
            }

            return animeInfo;
        }

        public List<Anime>? GetAnimes(int page = 1, string? name = null)
        {
            // season
            string param = $"api/animes?limit=50&page={page}&order=ranked";
            if (name != null)
                param += $"&search={name}";
            List<Anime>? animes = new List<Anime>();
            HttpResponseMessage response = httpClient.GetAsync(param).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                animes = JsonSerializer.Deserialize<List<Anime>>(json);
            }

            return animes;
        }

        public List<Genre>? GetGenres()
        {
            string param = "api/genres";
            List<Genre>? genres = new List<Genre>();
            HttpResponseMessage response = httpClient.GetAsync(param).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                genres = JsonSerializer.Deserialize<List<Genre>>(json);
            }
            return genres.Where(o => o.Kind == "anime").ToList();
        }
    }
}
