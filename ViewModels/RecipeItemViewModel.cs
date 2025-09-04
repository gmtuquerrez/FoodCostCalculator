using System.ComponentModel.DataAnnotations;

namespace FoodCostCalculator.ViewModels
{
    public class RecipeItemViewModel
    {
        [Required]
        [Display(Name = "Ingrediente")]
        public int ItemId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Cantidad debe ser mayor a 0")]
        public decimal Quantity { get; set; }

        [Display(Name = "Unidad")]
        public string Unit { get; set; } = string.Empty;

        [Display(Name = "Costo")]
        public decimal Cost { get; set; }

        [Display(Name = "Canales de venta")]
        public List<string> SalesChannels { get; set; } = new();
    }
}
