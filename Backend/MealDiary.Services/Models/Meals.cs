﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealDiary.Services.Models;

[Table("Meals")]
public class Meals
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime DateAdded { get; set; }
    public decimal Price { get; set; }
    public int Rating { get; set; }
    public string? Description { get; set; }
    public string? Review { get; set; }
    public string MealCourse { get; set; }
    public string? ShareLink { get; set; }
    public DateTime? ShareLinkDate { get; set; }
    
    [ForeignKey("Cuisines")]
    public int? CuisineTypeId { get; set; }
    [ForeignKey("Users")]
    public int? UsersId { get; set; }
    [ForeignKey("Ingredients")]
    public int? IngredientId { get; set; }
    [ForeignKey("Images")]
    public int? ImageId { get; set; }
}