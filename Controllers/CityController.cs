using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HSPA_Web_Api.Data;
using HSPA_Web_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HSPA_Web_Api.Controllers
{
    [Route("api/[controller]")] // /api/city anu kontrooleris saxeli
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly DataContext dc;

        public CityController(DataContext dc)
        {
            this.dc = dc;
        }
        [HttpGet] // Get api/City
        public async Task<IActionResult> GetCities() { 
            var cities = await  dc.Cities.ToListAsync();
            return Ok(cities);
        }
        // Post api/city/add?cityname=Miami
        // Post api/city/add/Los Angeles
        [HttpPost("add")]
        [HttpPost("add/{cityName}")]
        public async Task<IActionResult> AddCity(string cityName)
        {
            City city = new City();
            city.Name = cityName;
            await dc.Cities.AddAsync(city);
            await dc.SaveChangesAsync();
            return Ok(city);
        }

        // Post api/city/ -- Post the data in Json Format
        [HttpPost("post")] 
        public async Task<IActionResult> AddCity(City city)
        {
            //city city = new city();
            //city.name = cityname;
            await dc.Cities.AddAsync(city);
            await dc.SaveChangesAsync();
            return Ok(city);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = await dc.Cities.FindAsync(id);
            
            dc.Cities.Remove(city);
            await dc.SaveChangesAsync();
            return Ok(id);
        }
    }
}
