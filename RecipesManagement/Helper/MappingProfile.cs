using AutoMapper;
using RecipesManagement.Models;
using RecipesManagement.ViewModels;

namespace RecipesManagement.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Recipe, RecipeCreateViewModel>()
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                .ReverseMap()
                .ForMember(dest => dest.Source, src => src.MapFrom(x => x.Source))
                .ReverseMap()
                .ForMember(dest => dest.Ingredients, src => src.MapFrom(x => x.Ingredients))
                .ReverseMap()
                .ForMember(dest => dest.Time, src => src.MapFrom(x => x.Time))
                .ReverseMap()
                .ForMember(dest => dest.Preparation, src => src.MapFrom(x => x.Preparation))
                .ReverseMap()
                .ForMember(dest => dest.PhotoPath, src => src.MapFrom(x => x.Photos))
                .ReverseMap();

            CreateMap<Ingredients, IngredientsViewModel>()
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                .ReverseMap()
                .ForMember(dest => dest.Quantinty, src => src.MapFrom(x => x.Quantity))
                .ReverseMap();           
        }
    }
}
