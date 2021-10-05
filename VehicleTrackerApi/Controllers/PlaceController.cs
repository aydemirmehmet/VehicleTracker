using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using NetTopologySuite;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackerApi.Data.Model;
using VehicleTrackerApi.Dto;
using VehicleTrackerApi.Helper;
using VehicleTrackerApi.Services.Base;

namespace VehicleTrackerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaceController : ControllerBase
    {
        private readonly IService _repository;
        private readonly IMapper _mapper;
        private readonly NtsGeometryServices _geometryServices;

        public PlaceController(IMapper mapper, IService repository, NtsGeometryServices geometryServices)
        {

            _repository = repository;
            _mapper = mapper;
            _geometryServices = geometryServices;
        }
        [HttpGet]
        [Produces("application/geo+json")]
        [ProducesResponseType(typeof(GeoJsonResultItem), 200)]
        public IActionResult Get()
        {
            var result = _repository.Places.GetAll().ToList();

      
            var CreateJson = new FeatureCollection();
           
            if (result != null)
            {

                
                foreach (var item in result)
                {
                    CreateJson.Add(new Feature
                    {
                        
                        Geometry = item.Location,
                        Attributes = new AttributesTable
                    {
                        {"Bölge Adı",item.Name }
                    },
                    });
                }
            }

            return Ok(CreateJson);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PlaceDto), 200)]
        public IActionResult Add([FromBody] PlaceDto entity)
        {
           var result= GeoShapeJsonParser.ParseGeoShapes(entity.Location);
            _geometryServices.CreateGeometryFactory();
            var place = new Place {
                  Name=entity.Name,
                  Location=result,

            };
       
            _repository.Places.Add(place);
           _repository.Complete();
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(PlaceDto), 200)]
        public IActionResult Update([FromBody] PlaceDto entity)
        {
            var result = GeoShapeJsonParser.ParseGeoShapes(entity.Location);
            _geometryServices.CreateGeometryFactory();
            var place = new Place
            {
                Id=entity.Id,
                Name = entity.Name,
                Location = result,

            };
            _repository.Places.Update(place);
            _repository.Complete();
            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(void), 200)]
        public IActionResult Delete(int Id)
        {
            var result = _repository.Places.Get(Id);
            if (result != null)
            {
                _repository.Places.Remove(result);
                _repository.Complete();
            }

            return Ok();
        }

    }
}
