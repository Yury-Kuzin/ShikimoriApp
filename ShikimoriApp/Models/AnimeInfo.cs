using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShikimoriApp.Models
{
    class AnimeInfo : Anime
    {
        public class ScreenshotItem
        {
            private string? original;
            [JsonPropertyName("original")]
            public string Original { get => $"https://shikimori.one{original}"; set => this.original = value; }
            private string? preview;
            [JsonPropertyName("preview")]
            public string Preview { get => $"https://shikimori.one{preview}"; set => this.preview = value; }
        }

        private string? description;
        [JsonPropertyName("description")]
        public string? Description
        {
            get => (new Regex(@"\[[а-яА-Я0-9a-zA-Z\/=]+\]").Replace(description ?? "", "")).ToString();
            set => this.description = value;
        }
        [JsonPropertyName("rating")]
        public string? Rating { get; set; }
        [JsonPropertyName("japanese")]
        public string[] Japanese { get; set; }
        [JsonPropertyName("screenshots")]
        public ScreenshotItem[] Screenshots { get; set; }
        [JsonPropertyName("duration")]
        public int Duration { get; set; }
        [JsonPropertyName("episodes")]
        public int Episodes { get; set; }
    }
}
