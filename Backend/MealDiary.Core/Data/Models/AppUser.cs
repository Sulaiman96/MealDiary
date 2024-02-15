using System.Collections;
using Microsoft.AspNetCore.Identity;

namespace MealDiary.Core.Data.Models;

public class AppUser: IdentityUser<int>
{
    public ICollection<Meal>? Meals { get; } = new List<Meal>();
    public ICollection<AppUserRole>? UserRoles { get; set; } = new List<AppUserRole>();
    public ICollection<MealCollection>? MealCollection { get; } = new List<MealCollection>();
    public ICollection<SharedMeal>? SharedMeals { get; set; } = new List<SharedMeal>();
    public ICollection<SharedMeal>? ReceivedMeals { get; set; } = new List<SharedMeal>();
    public ICollection<SharedMealCollection>? SharedMealCollections { get; set; } = new List<SharedMealCollection>();
    public ICollection<SharedMealCollection>? ReceivedMealCollections { get; set; } = new List<SharedMealCollection>();
}