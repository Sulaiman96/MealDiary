using AutoMapper;
using MealDiary.API.Data;

namespace MealDiary.API.Services;

public class BaseService
{
    protected readonly DataContext _context;
    protected readonly IMapper _mapper;

    public BaseService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}