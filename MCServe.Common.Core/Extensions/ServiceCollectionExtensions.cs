using Microsoft.Extensions.DependencyInjection;

namespace MCServe.Common.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommonCoreServices(this IServiceCollection services)
    {
        return services;
    }
}
