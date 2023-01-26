namespace MealDiary.Data.Models.DTOs;

public record UpsertMealDto(int id, string name, string location, DateTime dateAdded, decimal price, int rating, string? description,
    string? review, string mealCourse, string? shareLink, DateTime? shareLinkDate, string cuisine, IEnumerable<IngredientDb> ingredients)
{
    public int id { get; init; } = id;
    public string name { get; init; } = name;
    public string location { get; init; } = location;
    public DateTime dateAdded { get; init; } = dateAdded;
    public decimal price { get; init; } = price;
    public int rating { get; init; } = rating;
    public string? description { get; init; } = description;
    public string? review { get; init; } = review;
    public string mealCourse { get; init; } = mealCourse;
    public string? shareLink { get; init; } = shareLink;
    public DateTime? shareLinkDate { get; init; } = shareLinkDate;
    public string cuisine { get; init; } = cuisine;
    public IEnumerable<IngredientDb> ingredients { get; init; } = ingredients;
}