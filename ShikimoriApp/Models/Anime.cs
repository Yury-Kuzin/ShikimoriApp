using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace ShikimoriApp.Models
{
    class Anime
    {
        public class ImageList
        {
            private string original;
            [JsonPropertyName("original")]
            public string Original { get => $"https://shikimori.one{original}"; set => this.original = value; }
            private string preview;
            [JsonPropertyName("preview")]
            public string Preview { get => $"https://shikimori.one{preview}"; set => this.preview = value; }
            private string x96;
            [JsonPropertyName("x96")]
            public string X96 { get => $"https://shikimori.one{x96}"; set => this.x96 = value; }
            private string x48;
            [JsonPropertyName("x48")]
            public string X48 { get => $"https://shikimori.one{x48}"; set => this.x48 = value; }
        }
        [JsonPropertyName("id")]
        public int Id { get; set; } = 0;
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("russian")]
        public string Russian { get; set; }
        [JsonPropertyName("url")]
        public string URL { get; set; }
        [JsonPropertyName("kind")]
        public string Kind { get; set; }
        [JsonPropertyName("score")]
        public string Score { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("episodes")]
        public int Episodes { get; set; }
        [JsonPropertyName("episodes_aired")]
        public int EpisodesAired { get; set; }
        [JsonPropertyName("aired_on")]
        public string AiredOn { get; set; }
        [JsonPropertyName("released_on")]
        public string ReleasedOn { get; set; }
        [JsonPropertyName("image")]
        public ImageList? Image { get; set; }
    }
}
