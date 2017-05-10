using Newtonsoft.Json;

namespace MaratonaXamari.Shared
{
    public class Users
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
