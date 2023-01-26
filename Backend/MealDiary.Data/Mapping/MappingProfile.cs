using AutoMapper;
using MealDiary.Data.Models;
using MealDiary.Data.Models.DTOs;

namespace MealDiary.Data.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MealDto, MealDb>().ReverseMap();
        CreateMap<CreateMealDto, MealDb>();
    }
}