using System;
using aspdotnet_core_demo.Models;

namespace aspdotnet_core_demo.dto
{
    public class VehicleDto
    {

        /*
        public VehicleDto(string licencePlate, string model)
        {
            LicencePlate = licencePlate;
            Model = model;
        }
        */

        public string LicencePlate { get; set; }
        public string Model { get; set; }

        public Vehicle FromDto()
        {
            return new Vehicle(LicencePlate, Model);
        }

    }
}

