using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealDiary.Services.Models;

[Table("Users")]
public class Users
{
    [Key]
    public int Id { get; set; }
    public string Email { get; set; }
    public string User { get; set; }
    public string HashedPassword { get; set; }
}