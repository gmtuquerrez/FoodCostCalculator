using System.ComponentModel.DataAnnotations;

namespace FoodCostCalculator.ViewModels
{
    public class RecipeViewModel
    {
        [Required]
        [Display(Name = "Producto/Receta")]
        public string FinalProduct { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Porciones debe ser mayor a 0")]
        public int Portions { get; set; }

        [Required]
        [StringLength(16)]
        public string Unit { get; set; } = "Porcion";

        // Lista de ingredientes
        public List<RecipeItemViewModel> Ingredients { get; set; } = new();
    }
}
