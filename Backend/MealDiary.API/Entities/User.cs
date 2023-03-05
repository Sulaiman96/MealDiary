using System.ComponentModel.DataAnnotations;

namespace MealDiary.API.Entities;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }

    public ICollection<Meal> Meals { get; set; }
    public ICollection<MealCollection> MealCollection { get; set; }
}