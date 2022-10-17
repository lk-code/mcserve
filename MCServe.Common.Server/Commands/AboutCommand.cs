using Cocona;

namespace MCServe.Common.Server.Commands;

public class AboutCommand
{
    public AboutCommand()
    {

    }

    [Command("about")]
    public async Task PrintAbout()
    {
        Console.WriteLine($"print about content");
    }
}
