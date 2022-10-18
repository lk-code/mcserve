using Cocona.Builder;
using Cocona;
using MCServe.Common.Server.Extensions;
using MCServe.Java.Core.Extensions;
using MCServe.Common.Core.Extensions;
using Microsoft.Extensions.Configuration;

CoconaAppBuilder? builder = CoconaApp.CreateBuilder();

builder.AddAppConfiguration();

builder.Services.AddCommonCoreServices()
    .AddCommonServerServices()
    .AddJavaCoreServices();

CoconaApp? app = builder.Build();

app.AddMCServeCommands();

app.Run();