using MealDiary.API.Extensions;
using MealDiary.API.Middleware;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddCors();
    builder.Services.AddApplicationServices(builder.Configuration);
    builder.Services.AddIdentityServices(builder.Configuration);
}

var app = builder.Build();
{
    app.UseMiddleware<ExceptionMiddleware>();
    app.UseCors(b => b.AllowAnyHeader().WithOrigins("https://localhost:4200", "http://localhost:4200"));
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

