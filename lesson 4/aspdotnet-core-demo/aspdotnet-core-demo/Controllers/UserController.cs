using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using aspdotnet_core_demo.Models;

namespace aspdotnet_core_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
    [HttpGet]
    public IActionResult GetString()
        {
            return Ok("this controller is UserController");
        }
        [HttpPost]
        [Route("age")]
        public IActionResult SetAge(int age)
        {
            if (age < 18)
                return BadRequest("too young");
            else return Ok("great!");
                }

    }
}
