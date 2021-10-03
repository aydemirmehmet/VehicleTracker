using AutoMapper;
using VehicleTrackerApi.Data.Model;
using VehicleTrackerApi.Dto;

namespace VehicleTrackerApi.Mapping
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleDto>().ReverseMap();
        }

    }
}
