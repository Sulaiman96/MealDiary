namespace MealDiary.Core.Data.Models;

public class SharedMeal
{
    public int Id { get; set; }
    public DateTime ShareDate { get; set; }
    
    public int MealId { get; set; }
    public Meal Meal { get; set; } = new();

    public int SharedByUserId { get; set; }
    public AppUser SharedByAppUser { get; set; } = new();

    public int SharedWithUserId { get; set; }
    public AppUser SharedWithAppUser { get; set; } = new();
}