using AutoMapper;
using Kitchen.Web.Data;
using Kitchen.Web.Models;

namespace Kitchen.Web.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dish, DishViewModel>().ForAllMembers(opt => opt.Condition((source, dest, sourceMember, destMember) => (sourceMember != null)));
        }
    }
}
