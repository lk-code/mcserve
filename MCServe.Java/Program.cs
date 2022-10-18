using Cocona;
using Cocona.Builder;
using MCServe.Common.Core.Extensions;
using MCServe.Common.Server.Extensions;
using MCServe.Java.Core.Extensions;

CoconaAppBuilder? builder = CoconaApp.CreateBuilder();

builder.UseAppConfiguration()
    .UseServerConfiguration();

builder.Services.AddCommonCoreServices()
    .AddCommonServerServices()
    .AddJavaCoreServices();

CoconaApp? app = builder.Build();

app.AddServerConfiguration()
    .AddMCServeCommands();

app.Run();