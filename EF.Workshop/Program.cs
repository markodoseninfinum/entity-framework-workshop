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

dbContext.ChangeTracker.StateChanged += OnStateChanged;

var pet = dbContext.Pets.AsNoTracking().FirstOrDefault();

pet.Name = "Woof Woof";

dbContext.SaveChanges();

var updated = dbContext.Pets.FirstOrDefault();
Console.WriteLine("Pet after update");
SerializeAndWrite(updated);

void OnStateChanged(object? sender, EntityStateChangedEventArgs e)
{
    Console.WriteLine("Entity changed!");
    Console.WriteLine($"Old state: {e.OldState}, New state: {e.NewState}");
    SerializeAndWrite(e.Entry.Entity);
}

void SerializeAndWrite(object data)
{
    var jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions
    {
        ReferenceHandler = ReferenceHandler.IgnoreCycles
    });
    Console.WriteLine(jsonData);
}
