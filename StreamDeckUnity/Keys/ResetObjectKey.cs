using BarRaider.SdTools;

namespace StreamDeckUnity.Keys
{
    [PluginActionId("com.nicollasr.streamdeckunity.resetobject")]
    public class ResetObjectKey : Key<EmptySettings>
    {
        public ResetObjectKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            base.KeyPressed(payload);

            var pid = GetForeground().processId;

            if (IsUnityForeground(pid))
            {
                MessageServer.Send(pid.ToString(), new ResetObjectMessage());
            }
        }
    }

    public class ResetObjectMessage : Message
    {
    }
}
