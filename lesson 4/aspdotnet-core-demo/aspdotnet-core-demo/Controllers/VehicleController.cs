using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using aspdotnet_core_demo.Models;
using aspdotnet_core_demo.dto;

namespace aspdotnet_core_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private List<Vehicle> _vehicles = new(){
            new Vehicle("tru-677-d4t","lada"),
            new Vehicle("p0l-4b7-77","mini"),
            new Vehicle("5t7-777-11", "kia", new Models.User(27, "maurice", "lanelei", Gender.Other)),
            new Vehicle("er-56-455", "ford", new User(56, "bree", "streetstraat 30", Gender.Other))
            };

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
        [HttpGet]
        [Route("[action]")]
        public IActionResult BrowseVehicleList(string plate)
        {
            Vehicle vehicleFound = null;
            foreach(var vehicle in _vehicles)
            {
                if (vehicle.LicencePlate == plate) vehicleFound = vehicle;
            }
            if (vehicleFound == null)
                return NotFound("no vehicle with that plate number");
            else return Ok(vehicleFound);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult AddVehicleToList(string plate, string model)
        //public IActionResult AddVehicleToList(VehicleDto vehicle)
        {
            var vehicle = new VehicleDto(plate, model);
            //_vehicles.Add(vehicle.FromDto());
            return Ok(vehicle.FromDto());
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult AddUserToVehicle(string plate, int age, string name, string address, Gender gender)
                    //public IActionResult AddUserToVehicle(string plate, User user)

        {
            Vehicle vehicleToUpdate = null;

            foreach (var vehicle in _vehicles)
            {
                if (vehicle.LicencePlate == plate)
                {
                    vehicleToUpdate = vehicle;
                    vehicle.Owner = new User(age, name, address, gender);
                    //vehicle.Owner = user;
                 }
            }
            if (vehicleToUpdate == null)
                return NotFound("no such plate");
            else return Ok(_vehicles);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult DeleteVehicleFromList(string plate)
        {
            int originalLength = _vehicles.Count();

            Vehicle vehicleToDelete = null;

            foreach(var vehicle in _vehicles)
            {
                if (vehicle.LicencePlate == plate)
                {
                    vehicleToDelete = vehicle;
                    //_vehicles.Remove(vehicle); <== doesnt work?!
                }
            }
            if (vehicleToDelete == null)
                return NotFound("no such plate");
            else return Ok($"vehicle that was removed from list was; {vehicleToDelete.LicencePlate}. original vehicle list length was: {originalLength}. current length is: {_vehicles.Count()}");
        }
    }
}
