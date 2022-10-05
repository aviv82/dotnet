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
    public class FactoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetString()
        {
            return Ok("this controller is FactoryController");
        }
        [HttpGet]
        [Route("[action]/factoryname")]
        public IActionResult Findname([FromRoute] string factoryName)
        {
            return Ok($"factory name os {factoryName}");
        }
    }
}
