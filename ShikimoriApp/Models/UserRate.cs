using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShikimoriApp.Models
{
    class UserRate
    {
        [JsonPropertyName("target_id")]
        public int AnimeID { get; set; } = 0;
        [JsonPropertyName("score")]
        public int Score { get; set; } = 0;
    }
}
