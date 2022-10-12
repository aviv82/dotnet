using System;
namespace AnotherInterfaceDemo.services
{
    public class BPost
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

