using System.Threading.Tasks;
using HSPA_Web_Api.Interfaces;
using HSPA_Web_Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HSPA_Web_Api.Controllers
{
    [Route("api/[controller]")] // /api/city anu kontrooleris saxeli
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork uow;

        public CityController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        [HttpGet] // Get api/City
        public async Task<IActionResult> GetCities() { 
            var cities = await  uow.CityRepository.GetCitiesAsync();
            return Ok(cities);
        }
     
        [HttpPost("post")]  // ttp://localhost:5000/api/city/post და ბოდიში ვწერთ {"name:"გორი"}
        public async Task<IActionResult> AddCity(City city)
        {
            uow.CityRepository.AddCity(city);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.CityRepository.DeleteCity(id);
            await uow.SaveAsync();
            return Ok(id);
        }

        // Post api/city/add?cityname=Miami
        // Post api/city/add/Los Angeles
        //[HttpPost("add")]
        //[HttpPost("add/{cityName}")]
        //public async Task<IActionResult> AddCity(string cityName)
        //{
        //    City city = new City();
        //    city.Name = cityName;
        //    await dc.Cities.AddAsync(city);
        //    await dc.SaveChangesAsync();
        //    return Ok(city);
        //}

    }
}
