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

    }
}
