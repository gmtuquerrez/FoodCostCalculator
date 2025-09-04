using FoodCostCalculator.Data;
using FoodCostCalculator.Models;
using FoodCostCalculator.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodCostCalculator.Controllers
{
    public class RecipeController : Controller
    {
        private readonly AppDbContext _context;

        public RecipeController(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET: Recipe
        public IActionResult Index()
        {
            var recipes = _context.Recipes
                .Include(r => r.Ingredients)      // Carga los RecipeItems
                .ThenInclude(ri => ri.Item)      // Carga el Item relacionado de cada RecipeItem
                .ToList();

            return View(recipes);
        }


        // GET: Recipe/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var recipe = await _context.Recipes
                .Include(r => r.Ingredients)
                .ThenInclude(ri => ri.Item)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null) return NotFound();

            return View(recipe);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Items = _context.Items.ToList();
            return View(new RecipeViewModel());
        }

        [HttpPost]
        public IActionResult Create(RecipeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Items = _context.Items.ToList();
                return View(model);
            }

            // Diccionario para el costo por canal
            var costPerChannel = new Dictionary<string, decimal>
    {
        { "DineIn", 0m },
        { "Delivery", 0m },
        { "Takeaway", 0m }
    };

            foreach (var ingredient in model.Ingredients)
            {
                var item = _context.Items.Find(ingredient.ItemId);
                if (item != null)
                {
                    ingredient.Unit = item.ConsumptionUnit;
                    ingredient.Cost = ingredient.Quantity * item.ConsumptionUnitCost;

                    if (ingredient.SalesChannels != null)
                    {
                        foreach (var channel in ingredient.SalesChannels)
                        {
                            if (costPerChannel.ContainsKey(channel))
                                costPerChannel[channel] += ingredient.Cost;
                        }
                    }
                }
            }

            var recipe = new Recipe
            {
                FinalProduct = model.FinalProduct,
                Portions = model.Portions,
                Unit = model.Unit,
                Ingredients = model.Ingredients.Select(i => new RecipeItem
                {
                    ItemId = i.ItemId,
                    Quantity = i.Quantity,
                    SalesChannels = i.SalesChannels != null ? string.Join(",", i.SalesChannels) : ""
                }).ToList()
            };

            _context.Recipes.Add(recipe);
            _context.SaveChanges();

            // Guardamos el costo en ViewBag en lugar de TempData
            ViewBag.CostPerChannel = costPerChannel;

            // Refrescamos la lista de items para el formulario
            ViewBag.Items = _context.Items.ToList();

            // Retornamos la vista directamente con el modelo
            return View(model);
        }
    }
}
