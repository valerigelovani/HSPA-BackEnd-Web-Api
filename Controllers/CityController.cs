using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HSPA_Web_Api.Controllers
{
    [Route("api/[controller]")] // /api/city anu kontrooleris saxeli
    [ApiController]
    public class CityController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get() { // axla roca chavwert linkshi /api/city amoagdebs am json arrays
            return new string[] { "Atlanta", "New York", "chicago" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        { // axla roca chavwert linkshi /api/city amoagdebs am json arrays
            return "Atlanta"; // axla rac ar unda cifri chavwerotot /api/city/ aq 1 2 an rac gvinda amoagdebs atlantas
        }
    }
}
