using AutoMapper;
using Kitchen.Web.Data;
using Kitchen.Web.Models;

namespace Kitchen.Web.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dish, DishViewModel>()
                .ForMember(src => src.CategoryName, opt => opt.MapFrom(dest => dest.Category != null ? dest.Category.Name : string.Empty))
                .ForMember(src => src.CategoryId, opt => opt.MapFrom(dest => dest.Category != null ? dest.Category.Id : 0));


        }
    }
}
