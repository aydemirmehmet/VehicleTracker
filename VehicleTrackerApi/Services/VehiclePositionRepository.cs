using VehicleApi.Contexts;
using VehicleTrackerApi.Data.Model;
using VehicleTrackerApi.Services.Base;

namespace VehicleTrackerApi.Services
{
    public class VehiclePositionRepository : GeneralRepository<VehiclePosition>, IVehiclePositionRepository
    {
        public VehiclePositionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }

}
