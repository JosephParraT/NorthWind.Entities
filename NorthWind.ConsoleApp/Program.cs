using Microsoft.Extensions.Hosting;
using NorthWind.ConsoleApp.Services;
using NorthWind.Entities.Interfaces;
using NorthWind.Writers;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

IUserActionWriter Writer = new ConsoleWriter();
HostApplicationBuilder Builder = Host.CreateApplicationBuilder();
Builder.Services.AddSingleton<IUserActionWriter, ConsoleWriter>();
Builder.Services.AddConsoleWriter();
Builder.Services.AddFileWriter();
Builder.Services.AddSingleton<IUserActionWriter, ConsoleWriter>();
Builder.Services.AddSingleton<AppLogger>();
Builder.Services.AddSingleton<ProductService>();
using IHost AppHost = Builder.Build();

AppLogger Logger = new AppLogger(Writer);
AppLogger Logger = AppHost.Services.GetRequiredService<AppLogger>();
Logger.WriteLog("Aplicacion started.");

ProductService Service = new ProductService(Writer);
ProductService Service = AppHost.Services.GetRequiredService<ProductService>();
Service.Add("Demo", "Azucar refinada");