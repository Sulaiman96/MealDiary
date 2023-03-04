using MealDiary.API.Data;
using MealDiary.API.Extensions;
using MealDiary.Data.Mapping;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
    builder.Services.AddDbContext<DataContext>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
    builder.Services.RegisterServices();
}


var app = builder.Build();
{
    app.MapControllers();
    app.Run();
}

