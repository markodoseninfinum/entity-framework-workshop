using EF.WOrkshop.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;

IServiceCollection services = new ServiceCollection();
IConfiguration configuration = new ConfigurationBuilder()
     .SetBasePath(Directory.GetCurrentDirectory())
     .AddJsonFile($"appsettings.json")
     .Build();

services.AddPersistence(configuration);


var serviceProvider = services.BuildServiceProvider();

serviceProvider.MigrateDatabase();

var dbContext = serviceProvider.GetService<AppDbContext>();

Console.WriteLine("Hello Workshop!");

var pet = dbContext.Pets.FirstOrDefault();

SerializeAndWrite(pet);

void SerializeAndWrite(object data)
{
    var jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions
    {
        ReferenceHandler = ReferenceHandler.IgnoreCycles
    });
    Console.WriteLine(jsonData);
}
