using NetTopologySuite.Geometries;
using System.Collections.Generic;

namespace VehicleTrackerApi.Data.Model
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Geometry Location { get; set; }

        public List<Report> Reports { get; set; }
    }
}
