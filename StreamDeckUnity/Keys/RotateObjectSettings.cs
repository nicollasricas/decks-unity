using Newtonsoft.Json;

namespace StreamDeckUnity.Keys
{
    public class RotateObjectSettings : KeySettings
    {
        [JsonProperty("axis")]
        public string Axis { get; set; }

        [JsonProperty("angle")]
        public float? Angle { get; set; }
    }
}
