using System.ComponentModel.DataAnnotations;

namespace MealDiary.API.Entities;

public class MealCollection
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedOn { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public ICollection<Meal> Meals { get; set; }
}