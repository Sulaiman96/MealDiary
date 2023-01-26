using AutoMapper;
using Dapper;
using MealDiary.Data.Models;
using MealDiary.Data.Models.DTOs;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace MealDiary.Data;

public class MealDiaryDatabase : IMealDiaryDatabase
{
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public MealDiaryDatabase(IConfiguration configuration, IMapper mapper)
    {
        _mapper = mapper;
        _configuration = configuration;
    }
    
    public async Task<MealDb> CreateMeal(MealDb meal)
    {
        var mealDb = _mapper.Map<MealDb>(meal);
        using var connection = new NpgsqlConnection(_configuration["ConnectionString"]);
        connection.Open();
 
        var sql = @"INSERT INTO meals (name, location, date_added, price, rating, description, review, meal_course, share_link, share_link_date)
                VALUES (@Name, @Location, @DateAdded, @Price, @Rating, @Description, @Review, @MealCourse, @ShareLink, @ShareLinkDate)
                RETURNING id, name, location, date_added, price, rating, description, review, meal_course, share_link, share_link_date";
        var parameters = new
        {
            Name = meal.Name,
            Location = meal.Location,
            DateAdded = meal.DateAdded,
            Price = meal.Price,
            Rating = meal.Rating,
            Description = meal.Description,
            Review = meal.Review,
            MealCourse = meal.MealCourse,
            ShareLink = meal.ShareLink,
            ShareLinkDate = meal.ShareLinkDate
        };
        var result = await connection.QuerySingleAsync<MealDb>(sql, parameters);
        return result;
    }

    public Task<bool> UpdateMeal(int id, MealDb meal)
    {
        throw new NotImplementedException();
    }

    public Task<MealDb> GetMeal(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteMeal(int id)
    {
        throw new NotImplementedException();
    }
}