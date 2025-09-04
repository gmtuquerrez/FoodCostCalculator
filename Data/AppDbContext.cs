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
                new Item { Id = 3, Name = "Plastic Bag", Category = "Intermediate", ConsumptionUnit = "Unit", ConsumptionUnitCost = 0.10m },
                new Item { Id = 4, Name = "Egg", Category = "RawMaterial", ConsumptionUnit = "Unit", ConsumptionUnitCost = 0.30m },
                new Item { Id = 5, Name = "Suggar", Category = "RawMaterial", ConsumptionUnit = "gr", ConsumptionUnitCost = 0.50m },
                new Item { Id = 6, Name = "Chocollate", Category = "RawMaterial", ConsumptionUnit = "gr", ConsumptionUnitCost = 0.10m },
                new Item { Id = 7, Name = "Flour", Category = "RawMaterial", ConsumptionUnit = "gr", ConsumptionUnitCost = 0.50m },
                new Item { Id = 8, Name = "Chocollate", Category = "RawMaterial", ConsumptionUnit = "gr", ConsumptionUnitCost = 0.10m },
                new Item { Id = 9, Name = "Evaporated milk", Category = "RawMaterial", ConsumptionUnit = "l", ConsumptionUnitCost = 1.60m },
                new Item { Id = 10, Name = "Milk", Category = "RawMaterial", ConsumptionUnit = "l", ConsumptionUnitCost = 1.40m },
                new Item { Id = 11, Name = "Tomato Sauce", Category = "RawMaterial", ConsumptionUnit = "gr", ConsumptionUnitCost = 0.80m },
                new Item { Id = 12, Name = "Cheese", Category = "RawMaterial", ConsumptionUnit = "gr", ConsumptionUnitCost = 1.50m },
                new Item { Id = 13, Name = "Pepperoni", Category = "RawMaterial", ConsumptionUnit = "gr", ConsumptionUnitCost = 2.00m },
                new Item { Id = 14, Name = "Box", Category = "RawMaterial", ConsumptionUnit = "Unit", ConsumptionUnitCost = 4.00m }
            );

            modelBuilder.Entity<Recipe>().HasData(
                new Recipe { Id = 1, FinalProduct = "Roast", Portions = 10, Unit = "Porcion" },
                new Recipe { Id = 2, FinalProduct = "Chocolate Cake", Portions = 8, Unit = "Porcion" },
                new Recipe { Id = 3, FinalProduct = "Pepperoni Pizza", Portions = 8, Unit = "Porcion" }
            );

            modelBuilder.Entity<RecipeItem>().HasData(
                new RecipeItem { Id = 1, RecipeId = 1, ItemId = 1, Quantity = 2.00000000m, SalesChannels = "DineIn,Delivery" },
                new RecipeItem { Id = 2, RecipeId = 1, ItemId = 2, Quantity = 1.50000000m, SalesChannels = "DineIn,Delivery" },
                new RecipeItem { Id = 3, RecipeId = 1, ItemId = 3, Quantity = 1.00000000m, SalesChannels = "Delivery" },
                new RecipeItem { Id = 4, RecipeId = 2, ItemId = 7, Quantity = 200.00m, SalesChannels = "DineIn,Delivery" }, // Flour
                new RecipeItem { Id = 5, RecipeId = 2, ItemId = 4, Quantity = 2.00m, SalesChannels = "DineIn,Delivery" },   // Eggs
                new RecipeItem { Id = 6, RecipeId = 2, ItemId = 5, Quantity = 100.00m, SalesChannels = "DineIn,Delivery" }, // Sugar
                new RecipeItem { Id = 7, RecipeId = 2, ItemId = 6, Quantity = 150.00m, SalesChannels = "DineIn,Delivery" }, // Chocolate
                new RecipeItem { Id = 8, RecipeId = 2, ItemId = 9, Quantity = 0.25m, SalesChannels = "DineIn,Delivery" },   // Evaporated Milk (0.25 l)
                new RecipeItem { Id = 9, RecipeId = 2, ItemId = 3, Quantity = 1.00m, SalesChannels = "Delivery" },           // Plastic Bag
                new RecipeItem { Id = 10, RecipeId = 3, ItemId = 4, Quantity = 1.00m, SalesChannels = "DineIn,Delivery" },   // Egg
                new RecipeItem { Id = 11, RecipeId = 3, ItemId = 10, Quantity = 0.25m, SalesChannels = "DineIn,Delivery" },  // Milk (0.25 l)
                new RecipeItem { Id = 12, RecipeId = 3, ItemId = 11, Quantity = 100.00m, SalesChannels = "DineIn,Delivery" },// Tomato Sauce
                new RecipeItem { Id = 13, RecipeId = 3, ItemId = 12, Quantity = 120.00m, SalesChannels = "DineIn,Delivery" },// Cheese
                new RecipeItem { Id = 14, RecipeId = 3, ItemId = 13, Quantity = 80.00m, SalesChannels = "DineIn,Delivery" }, // Pepperoni
                new RecipeItem { Id = 15, RecipeId = 3, ItemId = 14, Quantity = 1.00m, SalesChannels = "Delivery" }           // Plastic Bag
            );

        }
    }
}
