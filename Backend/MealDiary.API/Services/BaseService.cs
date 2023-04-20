using AutoMapper;
using MealDiary.API.Data;

namespace MealDiary.API.Services;

public class BaseService
{
    protected readonly DataContext _context;

    public BaseService(DataContext context)
    {
        _context = context;
    }
}