using Cocona.Builder;
using Cocona;
using MCServe.Common.Server.Extensions;
using MCServe.Java.Core.Extensions;
using MCServe.Common.Core.Extensions;

CoconaAppBuilder? builder = CoconaApp.CreateBuilder();

builder.Services.AddCommonCoreServices();
builder.Services.AddCommonServerServices();
builder.Services.AddJavaCoreServices();

CoconaApp? app = builder.Build();

app.AddMCServeCommands();

app.Run();