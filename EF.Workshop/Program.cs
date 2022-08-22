using EF.WOrkshop.Persistence;
using Microsoft.EntityFrameworkCore;
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


//var pets = dbContext.Pets.ToList();
//var owner = dbContext.Owners.FirstOrDefault(o => o.Name == "Marko Dosen");

//SerializeAndWrite(pets);
//SerializeAndWrite(owner);

//dbContext.ChangeTracker.LazyLoadingEnabled = false;

var pet = dbContext.Pets.FirstOrDefault();

var ownerName = pet?.Owner?.Name;

SerializeAndWrite(pet);
SerializeAndWrite($"Owner name: {ownerName}");
//Console.Read();


void SerializeAndWrite(object data)
{
    var jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions
    {
        ReferenceHandler = ReferenceHandler.IgnoreCycles
    });
    Console.WriteLine(jsonData);
}
