
namespace MealDiary.Core.Data.Models;

public class Photo
{
    public int Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public bool IsMainPhoto { get; set; }
    
    public int? MealId { get; set; }
    public Meal? Meal { get; set; }
}