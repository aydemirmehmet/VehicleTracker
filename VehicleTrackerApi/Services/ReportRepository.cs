using VehicleApi.Contexts;
using VehicleTrackerApi.Data.Model;
using VehicleTrackerApi.Services.Base;

namespace VehicleTrackerApi.Services
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        public ReportRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }

}
