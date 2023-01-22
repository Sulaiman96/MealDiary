using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealDiary.Services.Models;

[Table("Images")]
public class Images
{
    [Key]
    public int Id { get; set; }
    
    public string url { get; set; }
}