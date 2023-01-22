using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealDiary.Services.Models;

[Table("Ingredients")]
public class Ingredients
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
}