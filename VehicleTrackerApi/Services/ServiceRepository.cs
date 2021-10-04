using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApi.Contexts;
using VehicleTrackerApi.Services.Base;

namespace VehicleTrackerApi.Services
{
    public class ServiceRepository:IService
    {
        private readonly ApplicationDbContext _context;
        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
            Places = new PlaceRepository(_context);
            Vehicles = new VehicleRepository(_context);
        }
        public IPlaceRepository Places { get; private set; }
        public IVehicleRepository Vehicles { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
