﻿using Cocona.Builder;
using Cocona;
using MCServe.Common.Server.Extensions;

CoconaAppBuilder? builder = CoconaApp.CreateBuilder();

//builder.Services.TryAddSingleton<IHtmlRenderer, HtmlRenderer>();

CoconaApp? app = builder.Build();

app.ConfigureCommands();

app.Run();