using MCServe.Common.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MCServe.Java.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddJavaCoreServices(this IServiceCollection services)
    {
        services.TryAddSingleton<IGameServer, GameServer>();

        return services;
    }
}
