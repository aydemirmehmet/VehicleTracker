using System;
using System.Collections.Generic;

namespace VehicleTrackerApi.Data.Model
{
    public class Report
    {
        public int Id { get; set; }
        public DateTime CreateReportDate { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int PlaceId { get; set; }
        public Place Place { get; set; }
        public PlaceState ReportState { get; set; }

    }
}
