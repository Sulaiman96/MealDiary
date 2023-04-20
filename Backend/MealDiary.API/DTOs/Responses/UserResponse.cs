namespace MealDiary.API.DTOs.Responses;

public class UserResponse
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public IEnumerable<MealResponse> Meals { get; set; }
    public IEnumerable<MealCollectionResponse> MealCollections { get; set; }
}