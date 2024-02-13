using System.ComponentModel.DataAnnotations;

namespace MealDiary.Core.Data.DTOs.Requests;

public class LoginRequest
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public string Password { get; set; }
}