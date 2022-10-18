namespace MCServe.Common.Core.Interfaces
{
    public interface IServerConfiguration
    {
        public static Action<IServerConfiguration>? ServerConfigurationHandler = null;

        void LoadConfig(string path);
        T? GetConfig<T>(string key, object? defaultValue = null);
    }
}
