using System.ComponentModel.DataAnnotations.Schema;

namespace MealDiary.API.Entities;

[Table("Photos")]
public class Photo
{
    public int Id { get; set; }
    public string Url { get; set; }
    public bool IsMain { get; set; }
    public string PublicId { get; set; }
    
    public int MealId { get; set; }
    public Meal Meal { get; set; }
}