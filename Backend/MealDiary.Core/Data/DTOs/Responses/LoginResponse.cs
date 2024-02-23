namespace MealDiary.Core.Data.DTOs.Responses;

public class LoginResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}