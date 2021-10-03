using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehicleTrackerApi.Data.Model
{
    public class VehiclePosition
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Point Location { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
