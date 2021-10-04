﻿using NetTopologySuite;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackerApi.Data.Model;

namespace VehicleTrackerApi.Data
{
    public static class DefaultData
    {
        public static List<Vehicle> LoadVehicleData()
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);



            return new List<Vehicle>() { 
                    new Vehicle
                    {
                        Id=1,
                        RegisterNumber="04TT336",
                        CurrentLocation=geometryFactory.CreatePoint(new Coordinate(35.6,36.6))
        },
                    new Vehicle
                    {Id=2,
                        RegisterNumber="34ET336",
                          CurrentLocation=geometryFactory.CreatePoint(new Coordinate(35.6,36.6))
                  
                    },
                    new Vehicle
                    {Id=3,
                        RegisterNumber="04BT336",
                        CurrentLocation=geometryFactory.CreatePoint(new Coordinate(35.6,36.6))
                    },
                    new Vehicle
                    {Id=4,
                        RegisterNumber="04TA336",
                        CurrentLocation=geometryFactory.CreatePoint(new Coordinate(35.6,36.6))
                    },
                    new Vehicle
                    {Id=5,
                        RegisterNumber="04AT336",
                         CurrentLocation=geometryFactory.CreatePoint(new Coordinate(35.6,36.6))
                    },
                    new Vehicle
                    {Id=6,
                        RegisterNumber="12AZ1236",
                       CurrentLocation=geometryFactory.CreatePoint(new Coordinate(35.6,36.6))
                    }

            };

        }


        public static List<Place> LoadPlaceData()
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            Coordinate[] coordinate = { new Coordinate(35.6, 36.6), new Coordinate(35.7, 36.6), new Coordinate(35.7, 36.6), new Coordinate(35.6, 36.6) };
           

            return new List<Place>() { 
                    new Place
                    {
                        Id=2,
                        Name="test",
                          Location=geometryFactory.CreatePolygon(coordinate)
                    

                    }
            };
        }

        }
}