using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [Consumes("application/geo+json")]
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


        [HttpPost]
        [Consumes("application/geo+json")]
        [Produces("application/geo+json")]
        [ProducesResponseType(typeof(FeatureCollection), 200)]
        public IActionResult SaveVehicleLovation([FromBody] GeoJsonResultItem entity)
        {
          var model=  JsonConvert.SerializeObject(entity);

            return Ok();
        }


        [HttpPatch]
         public IActionResult SaveVehicleLovation([FromBody] VehicleDto entity)
        {
            var map= _mapper.Map<Vehicle>(entity);
            _repository.Vehicles.Add(map);
            _repository.Complete();
            return Ok(entity); 
        }

       

        [HttpDelete]
        [ProducesResponseType(typeof(void), 200)]
        public IActionResult Delete(int Id)
        { var result = _repository.Vehicles.GetById(Id);
            if (result != null)
            {
                _repository.Vehicles.Remove(result);
                _repository.Complete();
            }
           
            return Ok(); 
        }

    }
}
