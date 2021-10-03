﻿using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTrackerApi.Data.Model
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string RegisterNumber { get; set; }
        public Point CurrentLocation { get; set; }
       
        public List<VehiclePosition> VehiclePositions { get; set; }
        public List<Report> Reports { get; set; }
    }
}
