using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTrackerApi.Dto
{
    public class VehicleDto
    {
        public string RegisterNumber { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
    }
}
