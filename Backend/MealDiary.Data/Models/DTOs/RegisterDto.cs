using System.ComponentModel.DataAnnotations;

namespace MealDiary.Data.Models.DTOs;

public class RegisterDto
{
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
}