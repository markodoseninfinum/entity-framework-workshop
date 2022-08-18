// See https://aka.ms/new-console-template for more information
using EF.WOrkshop.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

IServiceCollection services = new ServiceCollection();
IConfiguration configuration = new ConfigurationBuilder()
     .SetBasePath(Directory.GetCurrentDirectory())
     .AddJsonFile($"appsettings.json")
     .Build();

services.AddPersistence(configuration);

Console.WriteLine("Hello Workshop!");
Console.Read();
