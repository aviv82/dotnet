using System;
using AnotherInterfaceDemo.services;
using AnotherInterfaceDemo.services.interfaces;


namespace AnotherInterfaceDemo;
public class WebShop
{
    public string Name { get; set; }


    // dependency injection:

    private readonly IShippingCompany _shippingCompany;
    //private readonly IPaymentService _paymentService;

    // we inject a value for the generic interface

    public WebShop(IShippingCompany shippingCompany, IPaymentService paymentService )
    {
        _shippingCompany = shippingCompany;
        //_paymentService = paymentService;
    }

    // with interface, much shorter, more modular:
    // here we will use a method injection for the payment and dependency injection for shipping
    public void OrderItem(Product product, Person person ,IPaymentService paymentService)
    {
        try
        {
            // when we create an instance we declare which company we want for our interface
            _shippingCompany.Ship(person.Address);
            paymentService.HandlePayment(product.Price, person.Address);

            //_paymentService.HandlePayment(product.Price, person.Address);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }


    /*
    // without interface, this is cumbersome:
    public void OrderItemFromBpost( Product product, Person person)
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

    public void OrderItemFromFedex(Product product, Person person)
    {
        try
        {
            //_shippingCompany.Ship(person.Address)
            var paymentService = new PayPal();
            paymentService.HandlePayment(product.Price, person.BankAcccountNumber);
            var shippingCompany = new FedEx();
            shippingCompany.Ship(person.Address);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
    */
}

