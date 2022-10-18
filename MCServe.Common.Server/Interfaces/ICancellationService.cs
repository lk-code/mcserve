namespace MCServe.Common.Server.Interfaces;

public interface ICancellationService
{
    CancellationToken CancellationToken { get; }
    void Cancel();
}