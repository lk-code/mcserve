using MCServe.Common.Server.Interfaces;
using MCServe.Common.Server.Services.Cancellation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MCServe.Common.Server.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommonServerServices(this IServiceCollection services)
    {
        services.TryAddSingleton<ICancellationService, CancellationService>();
        
        return services;
    }
}
