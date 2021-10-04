using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehicleTrackerApi.Data.Model
{
    public class Place: IEntity
    {
       
        public string Name { get; set; }
        public Geometry Location { get; set; }

        public List<Report> Reports { get; set; }

     

    }
}
