using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NetTopologySuite;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using NetTopologySuite.IO.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackerApi.Data.Model;
using VehicleTrackerApi.Dto;

using VehicleTrackerApi.Services.Base;

namespace VehicleTrackerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IService _repository;
        private readonly IMapper _mapper;
        private readonly NtsGeometryServices _geometryServices;
        public VehicleController(IMapper mapper, IService repository, NtsGeometryServices geometryServices)
        {

            _repository = repository;
            _mapper = mapper;
            _geometryServices = geometryServices;
        }

        [HttpGet]
        [Produces("application/geo+json")]
        [ProducesResponseType(typeof(FeatureCollection), 200)]
        public FeatureCollection Get()
        {
            var result = _repository.Vehicles.GetAll();
          
           
            var CreateJson = new FeatureCollection();
            foreach (var item in result)
            {
                CreateJson.Add(new Feature
                {
                    Geometry = item.CurrentLocation,
                    Attributes = new AttributesTable
                    {
                        {"Plaka",item.RegisterNumber }
                    },
                });
            }
   
            return CreateJson;
        }

        [HttpGet("RouteOfVehicle")]
        [Produces("application/geo+json")]
        [ProducesResponseType(typeof(FeatureCollection), 200)]
        public FeatureCollection RouteOfVehicle(int Id)
        {
            var result = _repository.VehiclePositions.GetAll( include: source => source.Include(x => x.Vehicle)).Where(x=>x.Vehicle.Id==Id).ToList();
        
           

            var CreateJson = new FeatureCollection();
            foreach (var item in result)
            {
                CreateJson.Add(new Feature
                {

                    Geometry = item.Location,
                    Attributes = new AttributesTable
                    {
                        {"Tarih",item.Date },
                        {"Plaka",item.Vehicle.RegisterNumber }
                    },
                });
            }

            return CreateJson;
        }
        [HttpPost]
   
        [ProducesResponseType(typeof(VehicleDto), 200)]
        public IActionResult Add([FromBody] VehicleDto entity)
        {
            var result = _mapper.Map<Vehicle>(entity);
            _repository.Vehicles.Add(result);
            _repository.Complete();
            return Ok(result);
        }


        [HttpPatch]
  
        [ProducesResponseType(typeof(VehicleDto), 200)]
        [ProducesResponseType(typeof(void), 400)]
        public IActionResult SaveLocation([FromBody] VehicleDto entity)
        {
           

                Vehicle vehicle = _mapper.Map<Vehicle>(entity);

                var Vehicleposition = new VehiclePosition
                {
                    Date=DateTime.Now,
                    Location = vehicle.CurrentLocation,
                    VehicleId = vehicle.Id
                };



                _repository.Vehicles.Update(vehicle);
                _repository.VehiclePositions.Add(Vehicleposition);
               var IsEnter = _repository.Vehicles.IsVehicleInPlace(vehicle,entity.State);
            if (IsEnter)
            {
                _repository.Complete();
            }
               


                return Ok(entity);
            
        }

      


        [HttpDelete]
        [ProducesResponseType(typeof(void), 200)]
        public IActionResult Delete(int Id)
        { var result = _repository.Vehicles.Get(Id);
            if (result != null)
            {
                _repository.Vehicles.Remove(result);
                _repository.Complete();
            }
           
            return Ok(); 
        }

    }
}
