using AutoMapper;
using MealDiary.Core.Data.DTOs.Requests;
using MealDiary.Core.Data.DTOs.Responses;
using MealDiary.Core.Data.Models;

namespace MealDiary.Core.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MealRequest, Meal>()
            .ForMember(dest => dest.Cuisine,
                opt => opt.MapFrom(src => new Cuisine {Name = src.Cuisine}));

        CreateMap<Photo, PhotoResponse>();

        CreateMap<MealCollection, MealCollectionResponse>();

        CreateMap<Ingredient, IngredientResponse>();

        CreateMap<MealIngredient, IngredientResponse>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Ingredient.Id))
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Ingredient.Name));
    }
}