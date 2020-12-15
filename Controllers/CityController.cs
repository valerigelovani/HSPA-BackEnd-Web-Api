using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HSPA_Web_Api.Dtos;
using HSPA_Web_Api.Interfaces;
using HSPA_Web_Api.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HSPA_Web_Api.Controllers
{
    [Route("api/[controller]")] // /api/city anu kontrooleris saxeli
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CityController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet] // Get api/City
        public async Task<IActionResult> GetCities() { 
            var cities = await  uow.CityRepository.GetCitiesAsync();
            var citiesDto = mapper.Map<IEnumerable<CityDto>>(cities); // automapperit igives vaketebt rac qvemot davweret
            return Ok(citiesDto);
        }
     
        [HttpPost("post")]  // ttp://localhost:5000/api/city/post და ბოდიში ვწერთ {"name:"გორი"}
        public async Task<IActionResult> AddCity(CityDto cityDto)
        {
            var city = mapper.Map<City>(cityDto);
            city.LastUpdatedBy = 1; // ყოველ დამატებულ მონაცემზე დაემატება ეს ფიქსირებულად ანუ ვინც დაპოსტა მისი აიდია დროებით ფიქსირებულია
            city.LastUpdatedOn = DateTime.Now; // ყოველ დამატებულ მონაცმეზე განახლდება დრო და დაემატება
            uow.CityRepository.AddCity(city);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]  //ttp://localhost:5000/api/city/update/1
        public async Task<IActionResult> UpdateCity(int id, CityDto cityDto)
        {
            var cityFromDb = await uow.CityRepository.FindCity(id);

            if (cityFromDb == null)
                return BadRequest("განახლება შეუძლებელია");

            cityFromDb.LastUpdatedBy = 1;
            cityFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(cityDto, cityFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }


        [HttpPut("updateCityName/{id}")]  //ttp://localhost:5000/api/city/update/1
        public async Task<IActionResult> UpdateCity(int id, CityUpdateDto cityDto)
        {
            var cityFromDb = await uow.CityRepository.FindCity(id);
            cityFromDb.LastUpdatedBy = 1;
            cityFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(cityDto, cityFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpPatch("update/{id}")]  //ttp://localhost:5000/api/city/update/1
        public async Task<IActionResult> UpdateCityPatch(int id, JsonPatchDocument<City> cityToPatch)
        {
            var cityFromDb = await uow.CityRepository.FindCity(id);
            cityFromDb.LastUpdatedBy = 1;
            cityFromDb.LastUpdatedOn = DateTime.Now;
            cityToPatch.ApplyTo(cityFromDb, ModelState);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.CityRepository.DeleteCity(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}
