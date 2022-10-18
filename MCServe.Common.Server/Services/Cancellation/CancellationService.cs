using MCServe.Common.Server.Interfaces;
using Microsoft.Extensions.Logging;

namespace MCServe.Common.Server.Services.Cancellation;

public class CancellationService : ICancellationService
{
    private readonly ILogger<CancellationService> _logger;
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    public CancellationToken CancellationToken
    {
        get
        {
            CancellationToken token = _cancellationTokenSource.Token;

            return token;
        }
    }

    public CancellationService(ILogger<CancellationService> logger)
    {
        this._logger = logger ?? throw new ArgumentNullException(nameof(logger));

        Console.CancelKeyPress += (s, e) =>
        {
            Console.WriteLine("Canceling...");

            this.Cancel();

            e.Cancel = true;
        };
    }

    public void Cancel()
    {
        this._cancellationTokenSource.Cancel();
    }
}