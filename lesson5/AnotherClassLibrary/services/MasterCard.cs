using System;
using AnotherInterfaceDemo.services.interfaces;

namespace AnotherInterfaceDemo.services
{
    public class MasterCard : IPaymentService
    {
        public MasterCard()
        {
        }

        public void HandlePayment(double price, string bankAccountNumber)
        {
            // handle payment
            Console.WriteLine($"payment by mastercard of: {price} to {bankAccountNumber} ");
        }
    }
}

