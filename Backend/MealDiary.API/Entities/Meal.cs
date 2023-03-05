using System.ComponentModel.DataAnnotations;

namespace MealDiary.API.Entities;

public class Meal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public decimal Price { get; set; }
    public string Review { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime? LastModified { get; set; } = DateTime.UtcNow;
    [Range(1, 10)] 
    public int Rating { get; set; }
    
    public int CuisineId { get; set; }
    public Cuisine Cuisine { get; set; }

    public int MealCollectionId { get; set; }
    public MealCollection MealCollection { get; set; }

    public ICollection<MealIngredient> MealIngredients { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}