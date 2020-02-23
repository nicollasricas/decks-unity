using BarRaider.SdTools;

namespace StreamDeckUnity.Keys
{
    [PluginActionId("com.nicollasr.streamdeckunity.pausemode")]
    public class PauseModeKey : Key<EmptySettings>
    {
        public PauseModeKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            base.KeyPressed(payload);

            var pid = GetForeground().processId;

            if (IsUnityForeground(pid))
            {
                MessageServer.Send(pid.ToString(), new PauseModeMessage());
            }
        }
    }
}