using FoodCostCalculator.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodCostCalculator.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeItem>? RecipeItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed sample data
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "Meat", Category = "RawMaterial", ConsumptionUnit = "Kg", ConsumptionUnitCost = 5.25m },
                new Item { Id = 2, Name = "Rice", Category = "RawMaterial", ConsumptionUnit = "Kg", ConsumptionUnitCost = 1.20m },
                new Item { Id = 3, Name = "Plastic Bag", Category = "Intermediate", ConsumptionUnit = "Unit", ConsumptionUnitCost = 0.10m }
            );

            modelBuilder.Entity<Recipe>().HasData(
                new Recipe { Id = 1, FinalProduct = "Roast", Portions = 10 }
            );

            modelBuilder.Entity<RecipeItem>().HasData(
                new RecipeItem { Id = 1, RecipeId = 1, ItemId = 1, Quantity = 2.00000000m, SalesChannels = "DineIn,Delivery" },
                new RecipeItem { Id = 2, RecipeId = 1, ItemId = 2, Quantity = 1.50000000m, SalesChannels = "DineIn,Delivery" },
                new RecipeItem { Id = 3, RecipeId = 1, ItemId = 3, Quantity = 1.00000000m, SalesChannels = "Delivery" }
            );

        }
    }
}
