using Cocona;
using MCServe.Common.Server.Commands;

namespace MCServe.Common.Server.Extensions;

public static class CoconaAppExtensions
{
    public static CoconaApp ConfigureCommands(this CoconaApp app)
    {
        app.AddCommands<AboutCommand>();

        return app;
    }
}
