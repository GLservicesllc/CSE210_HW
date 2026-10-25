using System;
using System.Collections.Generic;

public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa" ||
               _country.ToLower() == "united states";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public double GetShippingCost()
    {
        if (_address.IsInUSA())
        {
            return 5.00;
        }
        else
        {
            return 35.00;
        }
    }

    public string GetShippingLabel()
    {
        return $"{_name}\n{_address.GetFullAddress()}";
    }
}

public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(
        string name,
        string productId,
        double price,
        int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalPrice()
    {
        return _price * _quantity;
    }

    public string GetPackingLabel()
    {
        return $"{_name} ({_productId}) - Quantity: {_quantity}";
    }
}

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotal()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.GetTotalPrice();
        }

        total += _customer.GetShippingCost();

        return total;
    }

    public void DisplayOrder()
    {
        Console.WriteLine("PACKING LABEL");

        foreach (Product product in _products)
        {
            Console.WriteLine(product.GetPackingLabel());
        }

        Console.WriteLine();
        Console.WriteLine("SHIPPING LABEL");
        Console.WriteLine(_customer.GetShippingLabel());

        Console.WriteLine();
        Console.WriteLine($"Shipping cost: ${_customer.GetShippingCost():0.00}");
        Console.WriteLine($"Total price: ${CalculateTotal():0.00}");
        Console.WriteLine(new string('-', 40));
    }
}

public class Program
{
    public static void Main()
    {
        Address address1 = new Address(
            "123 Main Street",
            "Provo",
            "UT",
            "USA");

        Customer customer1 = new Customer(
            "Logan Brizzee",
            address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product(
            "Keyboard",
            "K100",
            45.99,
            1));

        order1.AddProduct(new Product(
            "Mouse",
            "M200",
            24.99,
            2));

        Address address2 = new Address(
            "45 Maple Road",
            "Toronto",
            "Ontario",
            "Canada");

        Customer customer2 = new Customer(
            "Alex Smith",
            address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product(
            "Headphones",
            "H300",
            79.99,
            1));

        order2.AddProduct(new Product(
            "USB Cable",
            "U400",
            12.50,
            3));

        order1.DisplayOrder();
        order2.DisplayOrder();
    }
}