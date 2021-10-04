using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTrackerApi.Dto
{
    public class PlaceDto
    {
        public string Name { get; set; }
        public Geometry Location { get; set; }
    }
}
