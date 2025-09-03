namespace FoodCostCalculator.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string FinalProduct { get; set; } = string.Empty; // Example: Roast, Pizza
        public int Portions { get; set; }
        public IEnumerable<RecipeItem>? Ingredients { get; set; } = new List<RecipeItem>();
    }
}
