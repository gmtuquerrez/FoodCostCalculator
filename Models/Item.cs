namespace FoodCostCalculator.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Example: Rice, Meat
        public string Category { get; set; } = string.Empty; // RawMaterial, Intermediate, Final
        public string ConsumptionUnit { get; set; } = string.Empty; // Example: "Kg", "Grams", "Unit"
        public decimal ConsumptionUnitCost { get; set; } // Example: 1.25 USD per unit
    }
}
