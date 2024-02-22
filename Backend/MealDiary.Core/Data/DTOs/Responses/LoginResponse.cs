namespace MealDiary.Core.Data.DTOs.Responses;

public class LoginResponse
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}