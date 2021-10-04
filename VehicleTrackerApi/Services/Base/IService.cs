using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTrackerApi.Services.Base
{
    public interface IService : IDisposable
    {
        IPlaceRepository Places { get;}
        IVehicleRepository Vehicles { get;  }
        int Complete();
    }
}
