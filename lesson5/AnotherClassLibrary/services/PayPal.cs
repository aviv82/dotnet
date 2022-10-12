using System;
namespace AnotherInterfaceDemo.services
{
    public class PayPal
    {
        
        public void HandlePayment(double price, string bankAccountNumber)
        {
            try
            {
                // handle payment
                if (bankAccountNumber == null) throw new Exception("account null");
                    else
                    Console.WriteLine($"handle payment for {price}, to {bankAccountNumber}");
                
            }
            catch (Exception ex)
            {

            }
        }
    }
}

