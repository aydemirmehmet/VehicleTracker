using VehicleApi.Contexts;
using VehicleTrackerApi.Data.Model;
using VehicleTrackerApi.Services.Base;

namespace VehicleTrackerApi.Services
{
    public class ReportRepository : GeneralRepository<Report>, IReportRepository
    {
        public ReportRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }

}
