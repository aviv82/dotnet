using AnotherInterfaceDemo.services;
using AnotherInterfaceDemo.services.interfaces;


namespace AnotherInterfaceDemo;
public class WebShop
{
    private readonly IShippingCompany _shippingCompany;



    public string Name { get; set; }

    public void OrderItem( Product product, Person person, IPaymentService paymentService)
    {
_shippingCompany.Ship(person.Address)

            }
}

