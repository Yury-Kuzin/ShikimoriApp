using ShikimoriApp.Exceptions;
using ShikimoriApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace ShikimoriApp
{
    public class ShikimoriContext
    {
        public enum ListStatus { Planned, Watching, Completed, Dropped };
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
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                throw new AnimeIDNotFoundException("Anime ID is Not found");

            return animeInfo;
        }

        public List<Anime>? GetAnimes(int page = 1, string? name = null, bool isProhibitedContent = true, int[]? genres = null)
        {
            string param = $"api/animes?limit=50&page={page}&order=ranked";
            if (name != null)
                param += $"&search={name}";
            if (genres != null)
            {
                param += $"&genre={string.Join(",", genres)}";
            }
            if (!isProhibitedContent)
            {
                param += "&rating=g,pg,pg_13";
            }
            List<Anime>? animes = new List<Anime>();
            HttpResponseMessage response = httpClient.GetAsync(param).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                animes = JsonSerializer.Deserialize<List<Anime>>(json);
            }

            return animes;
        }

        public Dictionary<DateOnly, List<CalendarItem>> GetCalendar()
        {
            string param = $"api/calendar";
            List<CalendarItem>? list = new List<CalendarItem>();
            Dictionary<DateOnly, List<CalendarItem>> dict = new Dictionary<DateOnly, List<CalendarItem>>();
            HttpResponseMessage response = httpClient.GetAsync(param).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                list = JsonSerializer.Deserialize<List<CalendarItem>>(json);
            }
            dict = list.GroupBy(o => DateOnly.FromDateTime(DateTime.Parse(o.NextEpisodeAt)))
                       .ToDictionary(i => i.Key, i => i.ToList());
            return dict;
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

        public List<AnimeInfo>? GetPersonalList(ListStatus status)
        {
            string param = $"api/v2/user_rates?user_id=1009362";
            switch (status)
            {
                case ListStatus.Planned:
                    param += "&status=planned";
                    break;
                case ListStatus.Completed:
                    param += "&status=completed";
                    break;
                case ListStatus.Dropped:
                    param += "&status=dropped";
                    break;
                case ListStatus.Watching:
                    param += "&status=watching";
                    break;
            }
            List<UserRate>? rates = new List<UserRate>();
            List<AnimeInfo>? animes = new List<AnimeInfo>();
            HttpResponseMessage response = httpClient.GetAsync(param).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                rates = JsonSerializer.Deserialize<List<UserRate>>(json);
            }
            foreach (UserRate item in rates)
            {
                AnimeInfo? anime = GetAnime(item.AnimeID);
                if (anime == null || anime.Name == null)
                    continue;
                animes.Add(anime);
            }
            return animes;
        }
    }
}
