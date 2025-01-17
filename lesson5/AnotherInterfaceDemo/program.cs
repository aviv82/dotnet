﻿using AnotherInterfaceDemo.services;
using AnotherInterfaceDemo;


Console.WriteLine("hello world");


var bPost = new BPost();
var fedex = new FedEx();

var master = new MasterCard();
var payapl = new PayPal();

var webshop = new WebShop(bPost);

var product = new Product();
product.Price = 5;
product.Name = "faucet";
product.Id = 1;
product.Description = "its a faucet";

var person = new Person();

person.BankAcccountNumber = "ddddddddddd";
person.Address = "onestraat 1";

webshop.OrderItem(product, person, master);
 

/*
// example of general interfaces:

List<IFueledVehicle> fueledVehicles = new List<IFueledVehicle>();
List<IVehicle> vehicles = new List<IVehicle>();
var bike = new Bike() { MaxSpeed = 5 };
var airplane = new Airplane() { MaxSpeed = 200 };
vehicles.Add(bike);
vehicles.Add(airplane);


foreach (var fueledVehicle in fueledVehicles)
{
    Console.WriteLine($"this is is a vehicle with a carbon footprint of {fueledVehicle.GetCarbonFootprint()}");
}

foreach (var vehicle in vehicles)
{
    if(vehicle is IFueledVehicle)
    {
        Console.WriteLine($"this is is a vehicle with a carbon footprint of {(vehicle as IFueledVehicle).GetCarbonFootprint()}");
    }
}


class Car : IVehicle, IFueledVehicle
{
    public int MaxSpeed {get; set;}
    public int PassangerSeats { get; set; }

    public int GetCarbonFootprint()
    {
        throw new NotImplementedException();
    }

    public int GetMaxSpeed()
    {
        return MaxSpeed;
    }
}

class Airplane : IVehicle, IFueledVehicle
{
    public int MaxSpeed { get; set; }
    public int PassangerSeats { get; set; }

    public int GetCarbonFootprint()
    {
        throw new NotImplementedException();
    }

    public int GetMaxSpeed()
    {
        throw new NotImplementedException();
    }
}

class Bike : IVehicle
{
    public int MaxSpeed { get; set; }

    public int GetMaxSpeed()
    {
        throw new NotImplementedException();
    }
}

interface IVehicle {
   int MaxSpeed { get; set; }
    int GetMaxSpeed();
}

interface IFueledVehicle
{
    int GetCarbonFootprint();
}
*/
