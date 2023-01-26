using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealDiary.Data.Models;

[Table("Ingredients")]
public class IngredientDb
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
}