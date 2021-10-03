using VehicleApi.Contexts;
using VehicleTrackerApi.Data.Model;
using VehicleTrackerApi.Services.Base;

namespace VehicleTrackerApi.Services
{
    public class PlaceRepository : Repository<Place>, IPlaceRepository
    {
        public PlaceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }

}
