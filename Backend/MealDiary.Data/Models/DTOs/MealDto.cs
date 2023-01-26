namespace MealDiary.Data.Models.DTOs;

public record MealDto()
{
    public MealDto(int id, string name, string location, DateTime dateAdded, decimal price, int rating, string mealCourse, string cuisine, 
    IEnumerable<IngredientDb> ingredients, string? shareLink= null, string? description= null, string? review = null, DateTime? shareLinkDate = null) : this()
    {
    }
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
    public string Cuisine { get; set; }
    public IEnumerable<IngredientDb> Ingredients { get; set; }
}