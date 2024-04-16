using Newtonsoft.Json;

namespace MyApp.Models
{
    public class County
    {
        [JsonProperty("abbreviation")]
        public string StateID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
