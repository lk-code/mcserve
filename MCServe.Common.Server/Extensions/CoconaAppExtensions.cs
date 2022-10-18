using Cocona;
using MCServe.Common.Server.Commands;

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
}