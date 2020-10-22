using AutoMapper;
using BGStudio.App.Models;
using BGStudio.BLL.Registration.Dto;

namespace BGStudio.BLL.MapProfiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UserERD, NewUserDto>();
        }
    }
}