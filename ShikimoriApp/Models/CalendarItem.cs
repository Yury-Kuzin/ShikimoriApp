using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShikimoriApp.Models
{
    class CalendarItem
    {
        [JsonPropertyName("duration")]
        public int? Duration { get; set; }
        [JsonPropertyName("next_episodes")]
        public int NextEpisodes { get; set; }
        [JsonPropertyName("next_episode_at")]
        public string? NextEpisodeAt { get; set; }
        [JsonPropertyName("anime")]
        public Anime? Anime { get; set; }
    }
}
