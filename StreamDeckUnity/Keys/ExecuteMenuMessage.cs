namespace StreamDeckUnity.Keys
{
    public class ExecuteMenuMessage : Message
    {
        public string Path { get; }

        public ExecuteMenuMessage(string path) => Path = path;
    }
}
