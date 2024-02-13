using Microsoft.AspNetCore.Identity;

namespace MealDiary.Core.Data.Models;

public class AppUserRole : IdentityUserRole<int>
{
    public AppUser User { get; set; }
    public AppRole Role { get; set; }
}