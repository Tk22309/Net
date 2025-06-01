using System;
using System.Collections.Generic;

namespace MauiLib3._1.Models
{
    public class DrinkModel
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public int Volume { get; set; }

        // Зв’язок: один напій → багато еспресо
        public required ICollection<EspressoModel> Espressos { get; set; }
    }
}
