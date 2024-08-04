namespace MealDiary.Core.Data.DTOs.Responses;

public class MealResponse
{
    public int id { get; set; }
    public string Name { get; set; }
    public string Restaruant { get; set; }
    public string Photo { get; set; }
    public decimal Price { get; set; }
    public string? Review { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime LastModified { get; set; }
    public int Rating { get; set; }
    public string? Cuisine { get; set; }
    public ICollection<MealCollectionResponse>? MealCollections { get; set; }
    public ICollection<IngredientResponse> Ingredients { get; set; }
    public ICollection<PhotoResponse> Photos { get; set; }
}