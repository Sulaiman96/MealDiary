namespace MealDiary.Core.Data.Models;

public class Cuisine
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Meal> Meals { get; } = new List<Meal>();
}