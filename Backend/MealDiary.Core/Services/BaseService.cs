using AutoMapper;
using MealDiary.Core.Data;

namespace MealDiary.Core.Services;

public class BaseService(ApplicationDbContext context)
{
    protected readonly ApplicationDbContext Context = context;
}