using Microsoft.AspNetCore.Identity;

namespace MealDiary.Core.Data.Models;

public class AppRole : IdentityRole<int>
{
    public ICollection<AppUserRole> UserRoles { get; set; }
}