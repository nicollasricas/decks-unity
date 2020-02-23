using BarRaider.SdTools;

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
}