using BarRaider.SdTools;

namespace StreamDeckUnity
{
    internal class Program
    {
        private static MessageServer messageServer;

        private static void Main(string[] args)
        {
            StartMessageServer();

#if DEBUG
            System.Console.ReadLine();
#else
            ConnectPlugin(args);
#endif

            StopMessageServer();
        }

        private static void StartMessageServer()
        {
            messageServer = new MessageServer();
            messageServer.Start();
        }

        private static void ConnectPlugin(string[] args) => SDWrapper.Run(args);

        private static void StopMessageServer() => messageServer?.Dispose();
    }
}
