using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackerApi.Data.Model;

namespace VehicleTrackerApi.Dto
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string RegisterNumber { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public PlaceState State { get; set; }
    }
}
