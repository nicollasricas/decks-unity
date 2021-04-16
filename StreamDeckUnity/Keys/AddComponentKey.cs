using BarRaider.SdTools;
using Newtonsoft.Json;

namespace StreamDeckUnity.Keys
{
    [PluginActionId("com.nicollasr.streamdeckunity.addcomponent")]
    public class AddComponentKey : Key<AddComponentSettings>
    {
        public AddComponentKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            base.KeyPressed(payload);

            var pid = GetForeground().processId;

            if (IsUnityForeground(pid))
            {
                MessageServer.Send(pid.ToString(), new AddComponentMessage(settings.Name));
            }
        }
    }

    public class AddComponentMessage : Message
    {
        public string Name { get; set; }

        public AddComponentMessage(string name) => Name = name;
    }

    public class AddComponentSettings : KeySettings
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}