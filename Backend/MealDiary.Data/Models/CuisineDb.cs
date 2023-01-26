using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealDiary.Data.Models;

[Table("Cuisines")]
public class CuisineDb
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
}