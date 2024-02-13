namespace MealDiary.Core.Data.Models;

public class SharedMealCollection
{
    public int Id { get; set; }
    public DateTime ShareDate { get; set; }
    
    public int MealCollectionId { get; set; }
    public MealCollection MealCollection { get; set; } = new();

    public int SharedByUserId { get; set; }
    public AppUser SharedByAppUser { get; set; } = new();

    public int SharedWithUserId { get; set; }
    public AppUser SharedWithAppUser { get; set; } = new();
}