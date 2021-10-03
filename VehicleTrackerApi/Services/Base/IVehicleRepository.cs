using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackerApi.Data.Model;

namespace VehicleTrackerApi.Services.Base
{
    public interface IVehicleRepository:IRepository<Vehicle>
    {
    }
}
