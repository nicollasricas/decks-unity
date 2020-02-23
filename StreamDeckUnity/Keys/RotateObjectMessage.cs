namespace StreamDeckUnity.Keys
{
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
}
