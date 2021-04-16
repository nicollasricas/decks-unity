using System;
using System.IO;
using BarRaider.SdTools;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace StreamDeckUnity
{
    internal class Program
    {
        private static MessageServer messageServer;

        private static void Main(string[] args)
        {
            try
            {
                var configuration = LoadConfiguration();

                StartMessageServer(configuration.Host, configuration.Port);

                ConnectPlugin(args);

                StopMessageServer();
            }
            catch (Exception exception)
            {
                Logger.Instance.LogMessage(TracingLevel.ERROR, exception.Message);
            }
        }

        private static Configuration LoadConfiguration()
        {
            var configuration = new Configuration();
            var configurationFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "StreamDeckUnity");
            var configurationFilePath = Path.Combine(configurationFolderPath, "settings.json");

            if (!File.Exists(configurationFilePath))
            {
                Logger.Instance.LogMessage(TracingLevel.INFO, $"Creating configuration file at {configurationFolderPath}");

                Directory.CreateDirectory(configurationFolderPath);

                File.WriteAllText(configurationFilePath, JsonConvert.SerializeObject(configuration, Formatting.Indented, new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }));

                return configuration;
            }

            Logger.Instance.LogMessage(TracingLevel.INFO, $"Loading configuration from {configurationFilePath}");

            JsonConvert.PopulateObject(File.ReadAllText(configurationFilePath), configuration);

            return configuration;
        }

        private static void StartMessageServer(string host, int port)
        {
            messageServer = new MessageServer(host, port);
            messageServer.Start();
        }

        private static void ConnectPlugin(string[] args) => SDWrapper.Run(args);

        private static void StopMessageServer() => messageServer?.Dispose();
    }
}
