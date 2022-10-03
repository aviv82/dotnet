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
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetString()
        {
            return Ok("hello from test controller");
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult Getboolean()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GeString(string stringValue, int intValue)
        {
            return Ok($"your values are: {stringValue}, and {intValue}");
        }

        [HttpGet]
        [Route ("stringParameter")]
        public IActionResult SetRouteParameter(string stringParameter)
        {
            return Ok($"your route parameter os: {stringParameter}");
        }
    }
}
