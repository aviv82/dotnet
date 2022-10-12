using System;
using AnotherInterfaceDemo.services;
//using AnotherInterfaceDemo.services.interfaces;


namespace AnotherInterfaceDemo;
public class WebShop
{
    //private readonly IShippingCompany _shippingCompany;



    public string Name { get; set; }

    public void OrderItem( Product product, Person person)
    {
        try
        {
            //_shippingCompany.Ship(person.Address)
            var paymentService = new PayPal();
            paymentService.HandlePayment(product.Price, person.BankAcccountNumber);
            var shippingCompany = new BPost();
            shippingCompany.Ship(person.Address);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}

