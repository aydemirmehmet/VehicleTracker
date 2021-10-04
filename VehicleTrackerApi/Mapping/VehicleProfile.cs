using AutoMapper;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using VehicleTrackerApi.Data.Model;
using VehicleTrackerApi.Dto;

namespace VehicleTrackerApi.Mapping
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            
            CreateMap<Vehicle, VehicleDto>().ReverseMap()
              .ForMember(dest => dest.CurrentLocation, opt => opt.MapFrom(x => geometryFactory.CreatePoint(new Coordinate(x.Longtitude, x.Latitude))));
        }
   

    }
}
