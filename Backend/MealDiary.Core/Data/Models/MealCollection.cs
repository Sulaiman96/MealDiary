namespace MealDiary.Core.Data.Models;

public class MealCollection
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; }
    
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    
    public ICollection<MealMealCollection> Meals { get; } = new List<MealMealCollection>();
    public ICollection<SharedMealCollection> SharedMealCollections { get; set; } = new List<SharedMealCollection>();
}