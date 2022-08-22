using EF.WOrkshop.Persistence;
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


var pets = dbContext.Pets.ToList();
var owner = dbContext.Owners.FirstOrDefault(o => o.Name == "Marko Dosen");

var jsonPet = JsonSerializer.Serialize(pets, new JsonSerializerOptions
{
    ReferenceHandler = ReferenceHandler.IgnoreCycles
});
var jsonOwner = JsonSerializer.Serialize(owner, new JsonSerializerOptions
{
    ReferenceHandler = ReferenceHandler.IgnoreCycles
});

Console.WriteLine(jsonPet);
Console.WriteLine(jsonOwner);
Console.Read();
