using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealDiary.Data.Models;

[Table("Lists")]
public class ListDb
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string ShareLink{ get; set; }
    public DateTime ShareLinkDate { get; set; }
    
    [ForeignKey("Users")]
    public int UsersId { get; set; }
}