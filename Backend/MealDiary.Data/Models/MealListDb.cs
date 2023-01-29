﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealDiary.Data.Models;

[Table("MealLists")]
public class MealListDb
{
    [Key]
    public int Id { get; set; }
    
    public ICollection<MealDb> Meals { get; set; }
    
    [ForeignKey("Lists")]
    public int listId { get; set; }
}