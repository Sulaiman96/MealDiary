using MealDiary.Services.Models;

namespace MealDiary.API.DTOModels;

public class MealResponse
{
    public MealResponse(
        int id, 
        string name,
        string location,
        DateTime dateAdded,
        decimal price,
        int rating,
        string? description,
        string? review,
        string mealCourse,
        string? shareLink,
        DateTime? shareLinkDate,
        IEnumerable<Cuisines> cuisines,
        IEnumerable<Ingredients> ingredients,
        IEnumerable<Images> images)
    {
        Id = id;
        Name = name;
        Location = location;
        DateAdded = dateAdded;
        Price = price;
        Rating = rating;
        Description = description;
        Review = review;
        MealCourse = mealCourse;
        ShareLink = shareLink;
        ShareLinkDate = shareLinkDate;
        Cuisines = cuisines;
        Ingredients = ingredients;
        Images = images;
    }

    public int Id { get; }
    public string Name { get; }
    public string Location { get; }
    public DateTime DateAdded { get; }
    public decimal Price { get; }
    public int Rating { get; }
    public string? Description { get; }
    public string? Review { get; }
    public string MealCourse { get; }
    public string? ShareLink { get; }
    public DateTime? ShareLinkDate { get; }
    public IEnumerable<Cuisines> Cuisines { get; }
    public IEnumerable<Ingredients> Ingredients { get; }
    public IEnumerable<Images> Images { get; }
}