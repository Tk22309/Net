using Coffe.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffe.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var service = new CrudServiceAsync<Drink>("drinks.json");

            var taskList = new List<Task>();
            for (int i = 0; i < 1000; i++)
            {
                taskList.Add(service.CreateAsync(Cocoa.CreateNew()));
            }

            await Task.WhenAll(taskList);
            await service.SaveAsync();

            var all = await service.ReadAllAsync();
            var min = all.Min(d => d.Volume);
            var max = all.Max(d => d.Volume);
            var avg = all.Average(d => d.Volume);

            Console.WriteLine("--- Статистика напоїв ---");
            Console.WriteLine($"Min: {min}, Max: {max}, Avg: {avg}");
            Console.WriteLine("Результати збережено у файл drinks.json");
        }
    }
}
