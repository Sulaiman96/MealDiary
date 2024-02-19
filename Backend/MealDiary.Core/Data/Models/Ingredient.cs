namespace MealDiary.Core.Data.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<MealIngredient> MealIngredients { get; } = new List<MealIngredient>();
}