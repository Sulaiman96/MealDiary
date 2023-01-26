using System.ComponentModel.DataAnnotations;

namespace MealDiary.Data.Models.DTOs;

public record CreateMealDto()
{
    public CreateMealDto(string name, string location, decimal price, int rating, string mealCourse, string cuisine,
        IEnumerable<IngredientDb> ingredients, string? description = null, string? review = null) : this()
    {
        
    }
    public string Name { get; init; }
    public string Location { get; init; }
    public decimal Price { get; init; }
    public int Rating { get; init; }
    public string MealCourse { get; init; }
    public string? Description { get; init; }
    public string? Review { get; init; }
    public string Cuisine { get; init; }
    public IEnumerable<IngredientDb> Ingredients { get; init; }
}