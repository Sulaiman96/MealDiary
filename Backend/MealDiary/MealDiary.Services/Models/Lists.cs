using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealDiary.Services.Models;

[Table("Lists")]
public class Lists
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string ShareLink{ get; set; }
    public DateTime ShareLinkDate { get; set; }
    
    [ForeignKey("Users")]
    public int UsersId { get; set; }

}