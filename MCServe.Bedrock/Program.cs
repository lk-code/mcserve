using Cocona;
using Cocona.Builder;
using MCServe.Bedrock.Core.Extensions;
using MCServe.Common.Core.Extensions;
using MCServe.Common.Server.Extensions;

CoconaAppBuilder? builder = CoconaApp.CreateBuilder();

builder.UseAppConfiguration()
    .UseServerConfiguration();

builder.Services.AddCommonCoreServices()
    .AddCommonServerServices()
    .AddBedrockCoreServices();

CoconaApp? app = builder.Build();

app.AddServerConfiguration()
    .AddMCServeCommands();

app.Run();