using Microsoft.EntityFrameworkCore;
using Drink.Infrastructure.Models;
using System.Collections.Generic;

namespace Drink.Infrastructure
{
    public class CoffeContext : DbContext
    {
        public CoffeContext(DbContextOptions<CoffeContext> options) : base(options) { }

        public DbSet<DrinkModel> Drinks { get; set; }
        public DbSet<EspressoModel> Espressos { get; set; }
        public DbSet<CappuccinoModel> Cappuccinos { get; set; }
        public DbSet<CocoaModel> Cocoas { get; set; }
        public DbSet<RafModel> Rafs { get; set; }
    }
}