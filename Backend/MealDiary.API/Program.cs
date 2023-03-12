using System.Text;
using MealDiary.API.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddCors();
    builder.Services.AddApplicationServices(builder.Configuration);
    builder.Services.AddIdentityServices(builder.Configuration);
}

var app = builder.Build();
{
    app.UseCors(b => b.AllowAnyHeader().WithOrigins("https://localhost:4200", "http://localhost:4200"));
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

