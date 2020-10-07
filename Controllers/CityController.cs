﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HSPA_Web_Api.Data;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        public IActionResult GetCities() { // axla roca chavwert linkshi /api/city amoagdebs am json arrays
            var cities = dc.Cities.ToList();
            return Ok(cities);
        }

    }
}
