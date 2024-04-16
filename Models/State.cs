using Newtonsoft.Json;

namespace MyApp.Models
{
    public class State
    {
        [JsonProperty("postal")]
        public string ID { get; set; }

        [JsonProperty("name")]
        public string Description { get; set; }
    }
}
