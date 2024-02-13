using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealDiary.Core.Data.Models;

public class Meal
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,2)")] 
    public decimal Price { get; set; }
    public string Review { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime? LastModified { get; set; } = DateTime.UtcNow;
    [Range(1, 5)] 
    public int Rating { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; } = new();
    public int UserId { get; set; }
    public AppUser AppUser { get; set; } = new();
    public int CuisineId { get; set; }
    public Cuisine Cuisine { get; set; } = new();
    public ICollection<Photo> Photos { get; set; } = new List<Photo>();
    public ICollection<MealIngredient> Ingredients { get; } = new List<MealIngredient>();
    public ICollection<MealMealCollection> MealCollections { get; } = new List<MealMealCollection>();
    public ICollection<SharedMeal> SharedMeals { get; set; } = new List<SharedMeal>();
}