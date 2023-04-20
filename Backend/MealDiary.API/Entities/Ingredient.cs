namespace MealDiary.API.Entities;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<MealIngredient> Meals { get; } = new List<MealIngredient>();
}