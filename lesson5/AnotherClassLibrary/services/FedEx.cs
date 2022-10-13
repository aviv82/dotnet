using System;
using AnotherInterfaceDemo.services.interfaces;

namespace AnotherInterfaceDemo.services
{
    public class FedEx: IShippingCompany
    {
        public void Ship(string address)
        {
            Console.WriteLine($"ship to {address}");
        }
    }
}

