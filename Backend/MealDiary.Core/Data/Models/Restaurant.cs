
namespace MealDiary.Core.Data.Models;

public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Meal> Meals { get; set; } = new List<Meal>();
}