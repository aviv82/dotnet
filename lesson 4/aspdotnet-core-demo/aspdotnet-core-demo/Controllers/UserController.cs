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

     private List<User> _users = new(){
            new User(22, "greg")
        };
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
    [HttpPost]
    [Route("[action]")]
    public IActionResult FindName([FromBody] string name)
        {
            return Ok($"my name is {name}");
        }
   }
}
