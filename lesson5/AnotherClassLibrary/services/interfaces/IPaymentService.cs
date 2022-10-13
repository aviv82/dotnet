using System;
namespace AnotherInterfaceDemo.services.interfaces
{
    public interface IPaymentService
    {
        void HandlePayment(double price, string bankAccountNumber);
        //{
        //    // handle payment
        //    Console.WriteLine($"pay {price} to {bankAccountNumber}");
        //}
    }

}

