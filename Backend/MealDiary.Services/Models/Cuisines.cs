using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealDiary.Services.Models;

[Table("Cuisines")]
public class Cuisines
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
}