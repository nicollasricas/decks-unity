using BarRaider.SdTools;
using Newtonsoft.Json;

namespace StreamDeckUnity.Keys
{
    [PluginActionId("com.nicollasr.streamdeckunity.executemenu")]
    public class ExecuteMenuKey : Key<ExecuteMenuSettings>
    {
        public ExecuteMenuKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            base.KeyPressed(payload);

            var pid = GetForeground().processId;

            if (IsUnityForeground(pid))
            {
                MessageServer.Send(pid.ToString(), new ExecuteMenuMessage(settings.Path));
            }
        }
    }

    public class ExecuteMenuMessage : Message
    {
        public string Path { get; }

        public ExecuteMenuMessage(string path) => Path = path;
    }

    public class ExecuteMenuSettings : KeySettings
    {
        [JsonProperty("path")]
        public string Path { get; set; }
    }
}