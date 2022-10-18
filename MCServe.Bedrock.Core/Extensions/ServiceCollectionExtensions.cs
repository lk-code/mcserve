using MCServe.Common.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MCServe.Bedrock.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBedrockCoreServices(this IServiceCollection services)
    {
        services.TryAddSingleton<IGameServer, GameServer>();

        return services;
    }
}
