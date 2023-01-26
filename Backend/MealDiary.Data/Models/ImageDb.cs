using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealDiary.Data.Models;

[Table("Images")]
public class ImageDb
{
    [Key]
    public int Id { get; set; }
    
    public string url { get; set; }
}