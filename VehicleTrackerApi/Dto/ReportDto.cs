using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackerApi.Data.Model;

namespace VehicleTrackerApi.Dto
{
    public class ReportDto
    {
        public DateTime CreateReportDate { get; set; }
        public string RegisterNumber { get; set; }
        public string Name { get; set; }
        public PlaceState State { get; set; }
    }
}
