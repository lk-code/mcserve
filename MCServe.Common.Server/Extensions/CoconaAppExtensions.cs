using Cocona;
using Cocona.Builder;
using MCServe.Common.Core.Interfaces;
using MCServe.Common.Core.Services.ServerConfiguration;
using MCServe.Common.Server.Commands;
using Microsoft.Extensions.Configuration;

namespace MCServe.Common.Server.Extensions;

public static class CoconaAppExtensions
{
    public static CoconaApp AddMCServeCommands(this CoconaApp app)
    {
        app.AddCommands<AboutCommands>();

        app.AddSubCommand("server", x =>
        {
            x.AddCommands<ServerCommands>();
        }).WithDescription("Server commands");

        return app;
    }

    public static CoconaApp AddServerConfiguration(this CoconaApp app)
    {
        // load the IServerConfiguration-service
        app.Services.GetService(typeof(IServerConfiguration));

        return app;
    }

    public static CoconaAppBuilder UseAppConfiguration(this CoconaAppBuilder builder)
    {
        builder.Host.ConfigureAppConfiguration((host, configurationBuilder) =>
        {
            configurationBuilder
            .AddJsonFile("appsettings.json")
#if DEBUG
            .AddJsonFile("appsettings.Development.json", optional: true)
#endif
            .AddEnvironmentVariables();
        });

        return builder;
    }

    public static CoconaAppBuilder UseServerConfiguration(this CoconaAppBuilder builder)
    {
        builder.ConfigureServerConfiguration((serverConfiguration) =>
        {
            serverConfiguration.LoadConfig("server.conf");
        });

        return builder;
    }

    public static void ConfigureServerConfiguration(this CoconaAppBuilder builder, Action<IServerConfiguration> serverConfiguration)
    {
        IServerConfiguration.ServerConfigurationHandler = serverConfiguration;
    }
}