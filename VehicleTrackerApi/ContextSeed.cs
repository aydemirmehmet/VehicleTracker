using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackerApi.Data;
using VehicleTrackerApi.Data.Model;

namespace VehicleTrackerApi
{
    public static class ContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            CreateVehicle(modelBuilder);

            CreatePlace(modelBuilder);

          
        }

        private static void CreateVehicle(ModelBuilder modelBuilder)
        {
            List<Vehicle> VehicleList = DefaultData.LoadVehicleData();
            modelBuilder.Entity<Vehicle>().HasData(VehicleList);
        }

        private static void CreatePlace(ModelBuilder modelBuilder)
        {
            List<Place> PlaceList = DefaultData.LoadPlaceData();
            modelBuilder.Entity<Place>().HasData(PlaceList);
        }

      
    }
}
