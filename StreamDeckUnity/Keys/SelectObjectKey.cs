using BarRaider.SdTools;
using Newtonsoft.Json;

namespace StreamDeckUnity.Keys
{
    [PluginActionId("com.nicollasr.streamdeckunity.selectobject")]
    public class SelectObjectKey : Key<SelectObjectSettings>
    {
        public SelectObjectKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            base.KeyPressed(payload);

            var pid = GetForeground().processId;

            if (IsUnityForeground(pid))
            {
                MessageServer.Send(pid.ToString(), new SelectObjectMessage(settings.Name, settings.Tag));
            }
        }
    }

    public class SelectObjectMessage : Message
    {
        public string Name { get; set; }

        public string Tag { get; set; }

        public SelectObjectMessage(string name, string tag)
        {
            Name = name;
            Tag = tag;
        }
    }

    public class SelectObjectSettings : KeySettings
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }
    }
}