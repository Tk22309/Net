using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Common
{
    public class Drink
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Volume { get; set; }

        public Drink(string name, int volume)
        {
            Id = Guid.NewGuid();
            Name = name;
            Volume = volume;
        }

        public static void Info()
        {
            Console.WriteLine("Базовий клас для напоїв");
        }
    }
}