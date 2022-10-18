using Cocona;

namespace MCServe.Common.Server.Commands;

public class AboutCommands
{
    public AboutCommands()
    {

    }

    [Command("about")]
    public async Task PrintAbout()
    {
        Console.WriteLine($"print about content");
    }
}
