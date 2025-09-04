namespace FoodCostCalculator.Models
{
    public class RecipeItem
    {
        public int Id { get; set; }

        // Relationship with Recipe
        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }

        // Relationship with Item
        public int ItemId { get; set; }
        public Item? Item { get; set; }
        public string Unit { get; set; } = string.Empty;
        public decimal Quantity { get; set; } // Up to 8 decimals
        public string SalesChannels { get; set; } = string.Empty; // Example: "DineIn,Takeaway,Delivery"
    }
}
