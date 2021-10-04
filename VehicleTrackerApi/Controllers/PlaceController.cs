using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using NetTopologySuite;
using NetTopologySuite.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackerApi.Data.Model;
using VehicleTrackerApi.Dto;
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
        [ProducesResponseType(typeof(FeatureCollection), 200)]
        public FeatureCollection Get()
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

            return CreateJson;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PlaceDto), 200)]
        public IActionResult Add([FromBody] PlaceDto entity)
        {
            var result = _mapper.Map<Place>(entity);
            _repository.Places.Add(result);
            _repository.Complete();
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(PlaceDto), 200)]
        public IActionResult Update([FromBody] PlaceDto entity)
        {
            var result = _mapper.Map<Place>(entity);
            _repository.Places.Update(result);
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
