using System;
namespace AnotherInterfaceDemo.services
{
    public class FedEx
    {
        public void Ship(string address)
        {
            Console.WriteLine($"ship to {address}");
        }
    }
}

