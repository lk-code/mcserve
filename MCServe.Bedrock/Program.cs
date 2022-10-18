using Cocona;
using Cocona.Builder;
using MCServe.Bedrock.Core.Extensions;
using MCServe.Common.Core.Extensions;
using MCServe.Common.Server.Extensions;

CoconaAppBuilder? builder = CoconaApp.CreateBuilder();

builder.AddAppConfiguration();

builder.Services.AddCommonCoreServices()
    .AddCommonServerServices()
    .AddBedrockCoreServices();

CoconaApp? app = builder.Build();

app.AddMCServeCommands();

app.Run();
