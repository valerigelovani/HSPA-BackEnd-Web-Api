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

        [HttpPost("add")] // Post api/City/add?cityname=Miami
        public async Task<IActionResult> AddCity(string cityName)
        {
            City city = new City();
            city.Name = cityName;
            await dc.Cities.AddAsync(city);
            await dc.SaveChangesAsync();
            return Ok(city);
        }
    }
}
