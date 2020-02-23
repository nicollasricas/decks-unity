using BarRaider.SdTools;

namespace StreamDeckUnity.Keys
{
    [PluginActionId("com.nicollasr.streamdeckunity.rotateobject")]
    public class RotateObjectKey : Key<RotateObjectSettings>
    {
        public RotateObjectKey(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void KeyPressed(KeyPayload payload)
        {
            base.KeyPressed(payload);

            var pid = GetForeground().processId;

            if (IsUnityForeground(pid))
            {
                MessageServer.Send(pid.ToString(), new RotateObjectMessage(settings.Axis, settings.Angle ?? 0));
            }
        }
    }
}
