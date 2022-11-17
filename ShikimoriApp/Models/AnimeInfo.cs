using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShikimoriApp.Models
{
    class AnimeInfo : Anime
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        [JsonPropertyName("url")]
        public string? Url { get; set; }
        [JsonPropertyName("rating")]
        public string? Rating { get; set; }
        [JsonPropertyName("japanese")]
        public string? Japanese { get; set; }
        [JsonPropertyName("screenshots")]
        public string? Screenshots { get; set; }



    }
}
