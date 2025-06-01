using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MauiLib3._1.Infrastructure;
using MauiLib3._1.Models;
using Drink.Infrastructure.Infrastructure.Services;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<CoffeContext>(options =>
            options.UseSqlite(context.Configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(ICrudServiceAsync<>), typeof(CrudServiceAsync<>));
    })
    .Build();

// Створюємо область видимості для сервісів
using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;

// Міграція (створення БД, якщо її ще немає)
var context = services.GetRequiredService<CoffeContext>();
await context.Database.MigrateAsync();

// Отримання сервісу CRUD
var drinkService = services.GetRequiredService<ICrudServiceAsync<DrinkModel>>();

// Додавання тестового напою
var newDrink = new DrinkModel
{
    Id = Guid.NewGuid(),
    Name = "Класичне еспресо",
    Volume = 50,
    Espressos = new List<EspressoModel>
    {
        new EspressoModel
        {
            Coffee = 8,
            SmallCup = 1,
            DrinkId = Guid.NewGuid(), // тимчасово, буде замінено після збереження
            Drink = null! // встановлюється після створення
        }
    }
};

await drinkService.CreateAsync(newDrink);

// Отримуємо та виводимо всі напої
var drinks = await drinkService.ReadAllAsync();
Console.WriteLine("--- Напої в базі ---");
foreach (var drink in drinks)
{
    Console.WriteLine($"ID: {drink.Id} | Назва: {drink.Name} | Обʼєм: {drink.Volume} мл");
}
