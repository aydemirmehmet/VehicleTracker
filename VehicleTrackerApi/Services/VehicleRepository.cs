using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApi.Contexts;
using VehicleTrackerApi.Data.Model;
using VehicleTrackerApi.Services.Base;

namespace VehicleTrackerApi.Services
{
    public class VehicleRepository : GeneralRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }


        public void IsVehicleInPlace(Vehicle entity)
        {
           
            Place VehicleInPlace = _context.Places.Where(x => x.Location.Contains(entity.CurrentLocation)).FirstOrDefault();
            if (VehicleInPlace != null)
            {
                var reportResult = _context.Reports.Where(x => x.PlaceId == entity.Id && x.ReportState == PlaceState.Enter).FirstOrDefault();
                if (reportResult == null)
                {
                    var CreateReport = new Report
                    {
                        CreateReportDate = DateTime.Now,
                        VehicleId = entity.Id,
                        PlaceId = VehicleInPlace.Id,
                        ReportState = PlaceState.Enter,
                    };
                    _context.Reports.Add(CreateReport);
                    
                }

            }

         
        }
    }

}
