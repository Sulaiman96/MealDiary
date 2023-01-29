using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealDiary.Data.Models;

[Table("Users")]
public class UserDb
{
    [Key]
    public int Id { get; set; }

    public string Email { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}