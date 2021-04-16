using BarRaider.SdTools;

namespace StreamDeckUnity.Keys
{
    [PluginActionId("com.nicollasr.streamdeckunity.togglescenegame")]
    public class ToggleSceneGameKey : Key<EmptySettings>
    {
        public ToggleSceneGameKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            base.KeyPressed(payload);

            var pid = GetForeground().processId;

            if (IsUnityForeground(pid))
            {
                MessageServer.Send(pid.ToString(), new ToggleSceneGameMessage());
            }
        }
    }

    public class ToggleSceneGameMessage : Message
    {
    }
}