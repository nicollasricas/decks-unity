using BarRaider.SdTools;
using Newtonsoft.Json;

namespace StreamDeckUnity.Keys
{
    [PluginActionId("com.nicollasr.streamdeckunity.toggleobjectstate")]
    public class ToggleObjectStateKey : Key<ToggleObjectStateSettings>
    {
        public ToggleObjectStateKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            base.KeyPressed(payload);

            var pid = GetForeground().processId;

            if (IsUnityForeground(pid))
            {
                MessageServer.Send(pid.ToString(), new ToggleObjectStateMessage(settings.State));
            }
        }
    }

    public class ToggleObjectStateMessage : Message
    {
        public int State { get; set; }

        public ToggleObjectStateMessage(int state)
        {
            State = state;
        }
    }

    public class ToggleObjectStateSettings : KeySettings
    {
        [JsonProperty("state")]
        public int State { get; set; }
    }
}