using MCServe.Common.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MCServe.Bedrock.Core;

public class GameServer : IGameServer
{
    private readonly ILogger<GameServer> _logger;
    private readonly IConfiguration _configuration;
    private readonly IServerConfiguration _serverConfiguration;

    Thread? _backgroundServer = null;

    public GameServer(ILogger<GameServer> logger,
        IConfiguration configuration,
        IServerConfiguration serverConfiguration)
    {
        this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this._configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        this._serverConfiguration = serverConfiguration ?? throw new ArgumentNullException(nameof(serverConfiguration));
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        Console.WriteLine("start game-server for minecraft bedrock");
        Console.WriteLine(this._serverConfiguration.GetConfig<string>("server-name"));

        if (this._backgroundServer != null)
        {
            Console.WriteLine("game-server already running");

            return;
        }

        this._backgroundServer = new Thread(async () => await RunAsync(cancellationToken));
        this._backgroundServer.Name = "MCServe Bedrock Server Instance";
        this._backgroundServer.Priority = ThreadPriority.Normal;
        this._backgroundServer.Start();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        Console.WriteLine("stop game-server");

        if (this._backgroundServer == null)
        {
            return;
        }

        this._backgroundServer.Abort();
    }

    private async Task RunAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // server logic
                Console.WriteLine(cancellationToken.IsCancellationRequested);
                Console.WriteLine(DateTime.Now.ToString());
                Thread.Sleep(1000);
            }
        }
        catch (Exception exception)
        {
            int i = 0;
        }
    }
}
