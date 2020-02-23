using Newtonsoft.Json;

namespace StreamDeckUnity.Keys
{
    public class ExecuteMenuSettings : KeySettings
    {
        [JsonProperty("path")]
        public string Path { get; set; }
    }
}