namespace MealDiary.API.DTOs.Responses;

public class MealResponse
{
    public int id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public decimal Price { get; set; }
    public string Review { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime LastModified { get; set; }
    public int Rating { get; set; }
    public string Cuisine { get; set; }
    public string CollectionName { get; set; }
    public IEnumerable<IngredientResponse> Ingredients { get; set; }
}