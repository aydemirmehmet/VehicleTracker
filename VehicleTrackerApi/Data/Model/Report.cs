using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehicleTrackerApi.Data.Model
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateReportDate { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int PlaceId { get; set; }
        public Place Place { get; set; }
        public PlaceState ReportState { get; set; }

    }
}
