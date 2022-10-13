using System;
using AnotherInterfaceDemo.services.interfaces;


namespace AnotherInterfaceDemo.services
{
    public class PayPal: IPaymentService
    {
        
        public void HandlePayment(double price, string bankAccountNumber)
        {
           if (bankAccountNumber == null) throw new Exception("account null");
           else
           // handle payment
           Console.WriteLine($"handle payment for {price}, to {bankAccountNumber}");
        }
    }
}

