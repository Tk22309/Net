using Microsoft.EntityFrameworkCore;
using MauiLib3._1.Models;
using System.Reflection.Emit;

namespace MauiLib3._1.Infrastructure
{
    public class CoffeContext : DbContext
    {
        public DbSet<DrinkModel> Drinks { get; set; }
        public DbSet<EspressoModel> Espressos { get; set; }
        public DbSet<CappuccinoModel> Cappuccinos { get; set; }
        public DbSet<RafModel> Rafs { get; set; }
        public DbSet<CocoaModel> Cocoas { get; set; }

        public CoffeContext(DbContextOptions<CoffeContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Table-per-Type (TPT) наслідування
            modelBuilder.Entity<EspressoModel>().ToTable("Espressos");
            modelBuilder.Entity<CappuccinoModel>().ToTable("Cappuccinos");
            modelBuilder.Entity<RafModel>().ToTable("Rafs");
            modelBuilder.Entity<CocoaModel>().ToTable("Cocoas");

            // Зв’язок 1:M (Drink → Espressos)
            modelBuilder.Entity<EspressoModel>()
                .HasOne(e => e.Drink)
                .WithMany(d => d.Espressos)
                .HasForeignKey(e => e.DrinkId);
        }
    }
}
