using BarRaider.SdTools;

namespace StreamDeckUnity.Keys
{
    [PluginActionId("com.nicollasr.streamdeckunity.pastecomponent")]
    public class PasteComponentKey : Key<EmptySettings>
    {
        public PasteComponentKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            base.KeyPressed(payload);

            var pid = GetForeground().processId;

            if (IsUnityForeground(pid))
            {
                MessageServer.Send(pid.ToString(), new PasteComponentMessage());
            }
        }
    }

    public class PasteComponentMessage : Message
    {
    }
}
