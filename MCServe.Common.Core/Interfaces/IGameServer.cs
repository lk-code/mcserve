namespace MCServe.Common.Core.Interfaces;

public interface IGameServer
{
    Task StartAsync(CancellationToken cancellationToken);
    Task StopAsync(CancellationToken cancellationToken);
}
