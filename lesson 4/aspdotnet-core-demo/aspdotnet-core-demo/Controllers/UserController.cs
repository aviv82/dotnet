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
            new User(22, "greg", "Bree 23", Gender.Other),
            new User(30, "tron", "Fuggerstraat 16", Gender.Other),
            new User(64, "lily", "Brouwersvliet 8", Gender.Female),
            new User(47, "mei", "Cellebroederstraat 59", Gender.Other)
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
        [HttpPost]
        [Route("[action]")]
        public IActionResult SetUser(User user)
        {
            return Ok($"hi, my name is {user.Name}, i am {user.Age} years old. my address is {user.Address} and i identify as {user.Gender}");
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult BrowseUserList(string name)
        {
            User userFound = null;
            foreach (var user in _users)
            {
                if (name == user.Name) userFound = user;
            }
            if (userFound == null)
                return NotFound("no such user");
            else return Ok($"hi, my name is {userFound.Name}, i am {userFound.Age} years old. i live in {userFound.Address}, and identify as {userFound.Gender}.");
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult AddNewUser(int age, string name, string address, Gender gender)
        {
            _users.Add(new Models.User(age, name, address, gender));
            return Ok(_users);
        }
   }
}
