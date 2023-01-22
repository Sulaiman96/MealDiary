namespace MealDiary.API.DTOModels;

public class UpsertMealRequest
{
    public UpsertMealRequest(
        string name, 
        string location, 
        decimal price, 
        int rating, 
        string mealCourse, 
        string? description, 
        string? review
    )
    {
        Name = name;
        Location = location;
        Price = price;
        Rating = rating;
        MealCourse = mealCourse;
        Description = description;
        Review = review;
    }
    public string Name { get; }
    public string Location { get; }
    public decimal Price { get; }
    public int Rating { get; }
    public string MealCourse { get; }
    public string? Description { get; }
    public string? Review { get; }
}