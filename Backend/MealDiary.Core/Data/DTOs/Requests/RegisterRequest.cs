using System.ComponentModel.DataAnnotations;

namespace MealDiary.Core.Data.DTOs.Requests;

public class RegisterRequest
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    [StringLength(maximumLength:16, MinimumLength = 8)]
    public string Password { get; set; }
}