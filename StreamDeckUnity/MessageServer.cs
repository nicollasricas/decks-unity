using BarRaider.SdTools;
using Fleck;
using Newtonsoft.Json;
using System.Collections.Concurrent;

namespace StreamDeckUnity
{
    public abstract class Message
    {
        public string Id { get; set; }
    }

    public class MessageServer
    {
        private readonly WebSocketServer server;

        private static readonly ConcurrentDictionary<string, IWebSocketConnection> connections = new ConcurrentDictionary<string, IWebSocketConnection>();

        private readonly string UnityPID = "X-Unity-PID";

        public MessageServer() => server = new WebSocketServer($"ws://127.0.0.1:18084");

        public void Start()
        {
            Logger.Instance.LogMessage(TracingLevel.INFO, $"Starting server {server.Location}.");

            server.Start(connection =>
            {
                connection.OnOpen = () => OnConnected(connection);
                connection.OnClose = () => OnDisconnected(connection);
                //connection.OnMessage = message => HandleMessages(connection, message);
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

        private void OnDisconnected(IWebSocketConnection connection)
        {
            connections.TryRemove(connection.ConnectionInfo.Cookies[UnityPID], out var _);
        }

        //private void HandleMessages(IWebSocketConnection connection, string rawMessage)
        //{
        //    Logger.Instance.LogMessage(TracingLevel.WARN, "Received messages::::::" + rawMessage);
        //}

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
