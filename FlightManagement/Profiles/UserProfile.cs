using AutoMapper;
using FlightManagement.DTO;
using FlightManagement.Entitys;

namespace FlightManagement.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

        }

    
    }
}
