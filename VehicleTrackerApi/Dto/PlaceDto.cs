using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTrackerApi.Dto
{
    public class PlaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GeoJsonResultItem Location { get; set; }
    }
}
