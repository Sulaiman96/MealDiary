using System.ComponentModel.DataAnnotations;

namespace MealDiary.Core.Data.DTOs.Requests;

public class RegisterRequest
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    [StringLength(8, MinimumLength = 4)]
    public string Password { get; set; }
}