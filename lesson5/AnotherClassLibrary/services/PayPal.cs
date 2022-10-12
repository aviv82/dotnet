using System;
namespace AnotherInterfaceDemo.services
{
    public class PayPal
    {
        
        public void HandlePayment(double price, string bankAccountNumber)
        {
            //handle payment
            Console.WriteLine($"handle payment for {price}, to {bankAccountNumber}");
        }
    }
}

