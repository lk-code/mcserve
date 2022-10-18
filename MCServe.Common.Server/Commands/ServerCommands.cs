using Cocona;
using MCServe.Common.Core.Interfaces;
using MCServe.Common.Server.Interfaces;

namespace MCServe.Common.Server.Commands;

public class ServerCommands
{
    private readonly IGameServer _gameServer;
    private readonly ICancellationService _cancellationService;

    public ServerCommands(IGameServer gameServer,
        ICancellationService cancellationService)
    {
        this._gameServer = gameServer ?? throw new ArgumentNullException(nameof(gameServer));
        this._cancellationService = cancellationService ?? throw new ArgumentNullException(nameof(cancellationService));
    }

    [OptionLikeCommand("start", new[] { 's' }, typeof(ServerCommands), nameof(StartGameServer))]
    [OptionLikeCommand("stop", new[] { 'e' }, typeof(ServerCommands), nameof(StopGameServer))]
    public void DefaultCommand()
    {
        Console.WriteLine($"for server command type: server --help");
    }


    private async Task StartGameServer()
    {
        await this._gameServer.StartAsync(this._cancellationService.CancellationToken);
    }

    private async Task StopGameServer()
    {
        await this._gameServer.StopAsync(this._cancellationService.CancellationToken);
    }
}
