using MCServe.Common.Core.Interfaces;
using MCServe.Common.Core.Services.ServerConfiguration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MCServe.Common.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommonCoreServices(this IServiceCollection services)
    {
        services.TryAddSingleton<IServerConfiguration, ServerConfiguration>();

        return services;
    }
}
