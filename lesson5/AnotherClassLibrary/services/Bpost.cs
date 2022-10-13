using System;
using AnotherInterfaceDemo.services.interfaces;


namespace AnotherInterfaceDemo.services
{
    public class BPost :IShippingCompany
    {
        public void Ship(string address)
        {
            // handle shipping
            Console.WriteLine($"shipping to {address}");
        }

        public void HandlePayment(double price, string bankAccountNumber)
        {
            //handle payment
            Console.WriteLine($"handle payment for {price}, to {bankAccountNumber}");
        }
    }
}

