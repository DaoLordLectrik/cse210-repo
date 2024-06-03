using System;
using System.Collections.Generic;

public class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public string Name { get => name; set => name = value; }
    public string ProductId { get => productId; set => productId = value; }
    public double Price { get => price; set => price = value; }
    public int Quantity { get => quantity; set => quantity = value; }

    public double TotalCost => Price * Quantity;
}

public class Address
{
    private string streetAddress;
    private string city;
    private string stateProvince;
    private string country;

    public string StreetAddress { get => streetAddress; set => streetAddress = value; }
    public string City { get => city; set => city = value; }
    public string StateProvince { get => stateProvince; set => stateProvince = value; }
    public string Country { get => country; set => country = value; }

    public bool IsInUSA()
    {
        return Country.ToLower() == "usa";
    }

    public override string ToString()
    {
        return $"{StreetAddress}\n{City}, {StateProvince}\n{Country}";
    }
}

public class Customer
{
    private string name;
    private Address address;

    public string Name { get => name; set => name = value; }
    public Address Address { get => address; set => address = value; }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }
}

public class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public List<Product> Products { get => products; set => products = value; }
    public Customer Customer { get => customer; set => customer = value; }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double totalCost = 0;
        foreach (var product in products)
        {
            totalCost += product.TotalCost;
        }
        totalCost += Customer.IsInUSA() ? 5 : 35;
        return totalCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (var product in products)
        {
            packingLabel += $"{product.Name}, ID: {product.ProductId}\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        string shippingLabel = "Shipping Label:\n";
        shippingLabel += $"{customer.Name}\n{customer.Address}";
        return shippingLabel;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create products
        Product product1 = new Product { Name = "Product 1", ProductId = "P001", Price = 10.99, Quantity = 2 };
        Product product2 = new Product { Name = "Product 2", ProductId = "P002", Price = 19.99, Quantity = 1 };
        Product product3 = new Product { Name = "Product 3", ProductId = "P003", Price = 8.49, Quantity = 3 };

        // Create customers
        Address address1 = new Address { StreetAddress = "123 Main St", City = "New Town", StateProvince = "CA", Country = "USA" };
        Customer customer1 = new Customer { Name = "Mac Winners", Address = address1 };

        Address address2 = new Address { StreetAddress = "456 House St", City = "Another Town", StateProvince = "ON", Country = "Canada" };
        Customer customer2 = new Customer { Name = "Dadzie Dazze", Address = address2 };

        // Create orders
        Order order1 = new Order { Customer = customer1 };
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order { Customer = customer2 };
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // Display order information
        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():0.00}\n");

        Console.WriteLine("Order 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():0.00}");
    }
}
