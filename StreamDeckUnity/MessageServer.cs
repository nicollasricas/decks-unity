using System.Collections.Concurrent;
using BarRaider.SdTools;
using Fleck;
using Newtonsoft.Json;

namespace StreamDeckUnity
{
    public class MessageServer
    {
        private readonly WebSocketServer server;

        private static readonly ConcurrentDictionary<string, IWebSocketConnection> connections = new ConcurrentDictionary<string, IWebSocketConnection>();

        private readonly string UnityPID = "X-Unity-PID";

        public MessageServer(string host, int port) => server = new WebSocketServer($"ws://{host}:{port}");

        public void Start()
        {
            Logger.Instance.LogMessage(TracingLevel.INFO, $"Starting server {server.Location}.");

            server.Start(connection =>
            {
                connection.OnOpen = () => OnConnected(connection);
                connection.OnClose = () => OnDisconnected(connection);
            });
        }

        private void OnConnected(IWebSocketConnection connection)
        {
            if (connection.ConnectionInfo.Cookies.TryGetValue(UnityPID, out var clientID))
            {
                Logger.Instance.LogMessage(TracingLevel.INFO, $"UNITY {clientID} connected.");

                connections[clientID] = connection;
            }
        }

        private void OnDisconnected(IWebSocketConnection connection) => connections.TryRemove(connection.ConnectionInfo.Cookies[UnityPID], out var _);

        public void Dispose() => server?.Dispose();

        public static void Send<T>(string clientID, T message) where T : Message
        {
            if (connections.TryGetValue(clientID, out var connection))
            {
                message.Id = typeof(T).Name;

                connection.Send(JsonConvert.SerializeObject(message));
            }
        }
    }
}
