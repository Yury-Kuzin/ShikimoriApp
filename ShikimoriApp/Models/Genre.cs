using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShikimoriApp.Models
{
    public class Genre
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("russian")]
        public string Russian { get; set; }
        [JsonPropertyName("kind")]
        public string Kind { get; set; }
    }
}
