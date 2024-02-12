using AutoMapper;
using FlightManagement.DTO;
using FlightManagement.Entitys;

namespace FlightManagement.Profiles
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<Flight, FlightDTO>();
            CreateMap<FlightDTO, Flight>();

        }
    
    }
}
