using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aspdotnet_core_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetString()
        {
            return Ok("this controller is VehicleController");
        }
        [HttpPost]
        [Route("wheels")]
        public IActionResult CheckWheels(int wheels)
        {
            if (wheels < 4)
                return BadRequest("not enough wheels");
            else return Ok("sweet wheels!");
        }
    }
}
