using Cocona;
using Cocona.Builder;
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


    public static void AddAppConfiguration(this CoconaAppBuilder builder)
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
    }
}