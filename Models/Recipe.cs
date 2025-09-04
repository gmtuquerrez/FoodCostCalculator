using System.ComponentModel.DataAnnotations;

namespace FoodCostCalculator.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string FinalProduct { get; set; } = string.Empty; // Example: Roast, Pizza
        public int Portions { get; set; }

        [Required]
        [StringLength(16)]
        public string Unit { get; set; } = "Porcion";
        public IEnumerable<RecipeItem>? Ingredients { get; set; } = new List<RecipeItem>();
    }
}
