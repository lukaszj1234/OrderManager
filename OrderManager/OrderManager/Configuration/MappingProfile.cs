using AutoMapper;
using OrderManager.DataAccess.Models;
using OrderManager.ViewModels;

namespace OrderManager.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDetailViewModel>();
            CreateMap<User, UserDetailsViewModel>()
             .ForMember(dest => dest.EmailAdress, opt => opt.MapFrom(src => src.Email));
            CreateMap<UserDetailsViewModel,User>()
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailAdress));
        }
    }
}
