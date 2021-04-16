using BarRaider.SdTools;
using Newtonsoft.Json;

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

    public class RotateObjectMessage : Message
    {
        public string Axis { get; set; }

        public float Angle { get; set; }

        public RotateObjectMessage(string axis, float angle)
        {
            Axis = axis;
            Angle = angle;
        }
    }

    public class RotateObjectSettings : KeySettings
    {
        [JsonProperty("axis")]
        public string Axis { get; set; }

        [JsonProperty("angle")]
        public float? Angle { get; set; }
    }
}
