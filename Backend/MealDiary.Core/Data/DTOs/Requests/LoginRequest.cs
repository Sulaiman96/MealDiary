using System.ComponentModel.DataAnnotations;

namespace MealDiary.Core.Data.DTOs.Requests;

public class LoginRequest
{
    [Required]
    public string UserName { get; set; }

    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
}