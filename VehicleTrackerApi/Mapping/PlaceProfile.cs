using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackerApi.Data.Model;
using VehicleTrackerApi.Dto;

namespace VehicleTrackerApi.Mapping
{
    public class PlaceProfile:Profile
    {
        public PlaceProfile()
        {
            CreateMap<Place, PlaceDto>().ReverseMap();
        }
    }
}
