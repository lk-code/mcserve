using MCServe.Common.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace MCServe.Common.Core.Services.ServerConfiguration
{
    public class ServerConfiguration : IServerConfiguration
    {
        private readonly ILogger<ServerConfiguration> _logger;

        private Dictionary<string, string> _config = new();

        public ServerConfiguration(ILogger<ServerConfiguration> logger)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));

            if (IServerConfiguration.ServerConfigurationHandler != null)
            {
                IServerConfiguration.ServerConfigurationHandler(this);
            }
        }

        public void LoadConfig(string path)
        {
            string executableDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            string serverConfPath = Path.Combine(executableDirectory, path);

            string serverConfContent = File.ReadAllText(serverConfPath);

            var config = serverConfContent.Split(Environment.NewLine)
                .Where(line => !string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
                .Select(line => line.Split("="))
                .ToDictionary(line => line[0], line => line[1]);

            this._config = config;
        }

        public T? GetConfig<T>(string key, object? defaultValue = null)
        {
            if (!this._config.ContainsKey(key.ToLowerInvariant()))
            {
                if (defaultValue != null)
                {
                    return (T)defaultValue;
                }

                return default(T);
            }

            string plainValue = this._config[key.ToLowerInvariant()];
            T value = (T)Convert.ChangeType(plainValue, typeof(T));
            return value;
        }
    }
}
