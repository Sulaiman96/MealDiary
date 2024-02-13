namespace MealDiary.Core.Data.Models;

public class MealIngredient
{
    public int MealId { get; set; }
    public Meal Meal { get; set; }

    public int IngredientId { get; set; }
    public Ingredient Ingredient { get; set; }
}