using MealDiary.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealDiary.API.Data;

public class DataContext : DbContext
{
    // private readonly IConfiguration _configuration;
    // public DataContext() 
    // {
    // }
    //
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    
    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    // {
    //     if (!options.IsConfigured)
    //     {
    //         options.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
    //     }
    // }
    
    public DbSet<User?> Users { get; set; } 
}