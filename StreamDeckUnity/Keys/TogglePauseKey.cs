using BarRaider.SdTools;

namespace StreamDeckUnity.Keys
{
    [PluginActionId("com.nicollasr.streamdeckunity.togglepause")]
    public class TogglePauseKey : Key<EmptySettings>
    {
        public TogglePauseKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            base.KeyPressed(payload);

            var pid = GetForeground().processId;

            if (IsUnityForeground(pid))
            {
                MessageServer.Send(pid.ToString(), new TogglePauseMessage());
            }
        }
    }

    public class TogglePauseMessage : Message
    {
    }
}