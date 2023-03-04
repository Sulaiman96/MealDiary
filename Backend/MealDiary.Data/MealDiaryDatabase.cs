// using AutoMapper;
// using Dapper;
// using MealDiary.Data.Models;
// using MealDiary.Data.Models.DTOs;
// using Microsoft.Extensions.Configuration;
//
// namespace MealDiary.Data;
//
// public class MealDiaryDatabase : IMealDiaryDatabase
// {
//     private readonly IConfiguration _configuration;
//     private string userColumns = "email, hashed_password, hashed_salt";
//
//     public MealDiaryDatabase(IConfiguration configuration)
//     {
//         _configuration = configuration;
//     }
//     
//     public async Task<MealDb> CreateMeal(MealDb meal)
//     {
//         await using var connection = new NpgsqlConnection(_configuration["ConnectionString"]);
//         connection.Open();
//  
//         const string sql = @"INSERT INTO meals (name, location, date_added, price, rating, description, review, meal_course, share_link, share_link_date)
//                 VALUES (@Name, @Location, @DateAdded, @Price, @Rating, @Description, @Review, @MealCourse, @ShareLink, @ShareLinkDate)
//                 RETURNING id, name, location, date_added, price, rating, description, review, meal_course, share_link, share_link_date";
//         var parameters = new
//         {
//             meal.Name,
//             meal.Location,
//             meal.DateAdded,
//             meal.Price,
//             meal.Rating,
//             meal.Description,
//             meal.Review,
//             meal.MealCourse
//         };
//         var result = await connection.QuerySingleAsync<MealDb>(sql, parameters);
//         return result;
//     }
//
//     public Task<bool> UpdateMeal(int id, MealDb meal)
//     {
//         throw new NotImplementedException();
//     }
//
//     public Task<MealDb> GetMeal(int id)
//     {
//         throw new NotImplementedException();
//     }
//
//     public Task<bool> DeleteMeal(int id)
//     {
//         throw new NotImplementedException();
//     }
//
//     //TODO - DOES NOT WORK!!!
//     public async Task<UserDb> GetUser(string email)
//     {
//         using var connection = new NpgsqlConnection(_configuration["ConnectionString"]);
//         var sql = $"SELECT {userColumns} FROM users WHERE email = @email";
//         var result = await connection.QueryFirstOrDefaultAsync<UserDb>(sql, new {email});
//         return result;
//     }
//
//     public async Task<UserDto> RegisterUser(UserDb user)
//     {
//         using var connection = new NpgsqlConnection(_configuration["ConnectionString"]);
//         var sql = $@"INSERT INTO users {userColumns}
//                 VALUES (@Email, @Hashed_Password, @Hashed_Salt)
//                 RETURNING id, email";
//         var parameters = new
//         {
//             Email = user.Email,
//             Hashed_Password = user.PasswordHash,
//             Hashed_Salt = user.PasswordSalt,
//         };
//         var result = await connection.QuerySingleAsync<UserDto>(sql, parameters);
//         return result;
//     }
// }