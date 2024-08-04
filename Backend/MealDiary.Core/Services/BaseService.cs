using AutoMapper;
using MealDiary.Core.Data;

namespace MealDiary.Core.Services;

public class BaseService(ApplicationDbContext context, IMapper mapper)
{
    protected readonly ApplicationDbContext Context = context;
    protected readonly IMapper Mapper = mapper;
}