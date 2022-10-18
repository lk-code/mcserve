using Cocona;
using Cocona.Builder;
using MCServe.Bedrock.Core.Extensions;
using MCServe.Common.Core.Extensions;
using MCServe.Common.Server.Extensions;
using MCServe.Common.Server.Interfaces;

CoconaAppBuilder? builder = CoconaApp.CreateBuilder();

builder.Services.AddCommonCoreServices();
builder.Services.AddCommonServerServices();
builder.Services.AddBedrockCoreServices();

CoconaApp? app = builder.Build();

app.AddMCServeCommands();

app.Run();