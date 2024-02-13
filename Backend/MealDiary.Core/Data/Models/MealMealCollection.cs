namespace MealDiary.Core.Data.Models;

public class MealMealCollection
{
    public int MealId { get; set; }
    public Meal Meal { get; set; } = new();

    public int MealCollectionId { get; set; }
    public MealCollection MealCollection { get; set; } = new();
}