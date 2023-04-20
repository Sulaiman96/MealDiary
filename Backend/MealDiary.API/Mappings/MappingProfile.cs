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
            .ForMember(dest => dest.CollectionName, 
                opt => opt.MapFrom(src => src.MealCollection.Name))
            .ForMember(dest => dest.Cuisine, 
                opt => opt.MapFrom(src => src.Cuisine.Name))
            .ForMember(dest => dest.PhotoUrl, 
                opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p=> p.IsMain).Url));

        CreateMap<MealRequest, Meal>()
            .ForMember(dest => dest.Cuisine,
                opt => opt.MapFrom(src => new Cuisine {Name = src.Cuisine}));

        CreateMap<User, UserResponse>()
            .ForMember(dest => dest.MealCollections, 
                opt => opt.MapFrom(src => src.MealCollection.Select(mc => new MealCollectionResponse
                {
                    Id = mc.Id,
                    Name = mc.Name,
                    CreatedOn = mc.CreatedOn
                })));

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