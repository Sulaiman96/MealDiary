using AutoMapper;
using MealDiary.API.DTOs.Requests;
using MealDiary.API.DTOs.Responses;
using MealDiary.API.Entities;

namespace MealDiary.API.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Meal, MealResponse>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Cuisine, opt => opt.MapFrom(src => src.Cuisine.Name))
            .ForMember(dest => dest.CollectionName, opt => opt.MapFrom(src => src.MealCollection.Name))
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.MealIngredients.Select(mi => mi.Ingredient)));
        
        CreateMap<MealRequest, Meal>()
            .ForMember(dest => dest.Cuisine, opt => opt.MapFrom(src => new Cuisine { Name = src.Cuisine }))
            .ForMember(dest => dest.MealCollection, opt => opt.MapFrom(src => new MealCollection { Name = src.CollectionName }))
            .ForMember(dest => dest.MealIngredients, opt => opt.MapFrom(src => src.Ingredients.Select(i => new MealIngredient { Ingredient = new Ingredient { Name = i.Name}})));
    }
}