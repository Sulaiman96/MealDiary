using AutoMapper;
using MealDiary.Core.Data.DTOs.Requests;
using MealDiary.Core.Data.DTOs.Responses;
using MealDiary.Core.Data.Models;

namespace MealDiary.Core.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Meal
        
        //CreateMap<MealRequest, Meal>().ForMember(dest => dest.Cuisine, opt => opt.MapFrom(src => new Cuisine {Name = src.Cuisine}));
        
        CreateMap<MealIngredient, IngredientResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Ingredient.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Ingredient.Name));
        
        CreateMap<MealMealCollection, MealCollectionResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MealCollection.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.MealCollection.Name))
            .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.MealCollection.CreatedOn));

        CreateMap<Meal, MealResponse>()
            .ForMember(dest => dest.MealCollections, opt => opt.MapFrom(src => src.MealCollections))
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.MealIngredients))
            .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMainPhoto == true).Url))
            .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos))
            .ForMember(dest => dest.Restaruant, opt => opt.MapFrom(src => src.Restaurant.Name))
            .ForMember(dest => dest.Cuisine, opt => opt.MapFrom(src => src.Cuisine.Name));
        
        CreateMap<Photo, PhotoResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))
            .ForMember(dest => dest.IsMainPhoto, opt => opt.MapFrom(src => src.IsMainPhoto));

        //User
        CreateMap<RegisterRequest, AppUser>();
        
        
        
    }
}