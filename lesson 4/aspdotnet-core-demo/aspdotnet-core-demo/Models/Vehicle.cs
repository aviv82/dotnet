using System;
namespace aspdotnet_core_demo.Models
{
    public class Vehicle
    {
        public Vehicle(string licensePlate, string model, User? user = null)
        {
            LicencePlate = licensePlate;
            Model = model;
            Owner = user;
        }
        public string LicencePlate { get; set; }
        public string Model { get; set; }
        public User? Owner { get; set; }
    }
}

