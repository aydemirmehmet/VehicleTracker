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


        public bool IsVehicleInPlace(Vehicle entity,PlaceState state)
        {
            bool check = false;
            Place VehicleInPlace = _context.Places.Where(x => x.Location.Contains(entity.CurrentLocation)).FirstOrDefault();
            if (VehicleInPlace != null)
            {
                var reportResult = _context.Reports.Where(x => x.VehicleId == entity.Id  ).FirstOrDefault();
                var CreateReport = new Report
                {
                    CreateReportDate = DateTime.Now,
                    VehicleId = entity.Id,
                    PlaceId = VehicleInPlace.Id,
                    ReportState = state,
                 
                  
                };
               

                if (reportResult == null)
                {
                   

                    CreateReport.IsFirstEnter = true;
                    _context.Reports.Add(CreateReport);
                    check = true;
                }
                else
                {
                    if (state == PlaceState.Enter)
                    {
                        CreateReport.IsFirstEnter = false;

                    }
                    else if (state == PlaceState.Exit)
                    {
                      
                            CreateReport.IsFirstEnter = true;
                            _context.Reports.Add(CreateReport);
                            check = true;
                        
                       
                    }

                }

            }

            return check;
        }
    }

}
