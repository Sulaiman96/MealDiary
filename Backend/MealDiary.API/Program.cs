using MealDiary.Services.QueryCommands;
using MealDiary.Services.StoreCommands;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTransient<IMealQueryCommand, MealQueryCommand>();
builder.Services.AddTransient<IMealStoreCommand, MealStoreCommand>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();