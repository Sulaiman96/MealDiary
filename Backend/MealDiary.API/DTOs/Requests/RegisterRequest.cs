using System.ComponentModel.DataAnnotations;

namespace MealDiary.API.DTOs.Requests;

public class RegisterRequest
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public string Password { get; set; }
}