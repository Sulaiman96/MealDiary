namespace MealDiary.API.DTOs;

public class MealRequest
{
    public string Name { get; set; }
    public string Location { get; set; }
    public decimal Price { get; set; }
    public string Review { get; set; }
    public int Rating { get; set; }
    public string Cuisine { get; set; }
    public string CollectionName { get; set; }
    public IEnumerable<IngredientRequest> Ingredients { get; set; }
}