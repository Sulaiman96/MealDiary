using System.ComponentModel.DataAnnotations;

namespace MealDiary.API.DTOs.Requests;

public class RegisterRequest
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    [StringLength(8, MinimumLength = 4)]
    public string Password { get; set; }
}