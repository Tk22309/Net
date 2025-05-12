using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Common
{
    public static class DrinkExtensions
    {
        public static void PrintInfo(this Drink drink)
        {
            Console.WriteLine($"Напій: {drink.Name}, Об'єм: {drink.Volume} мл");
        }
    }
}