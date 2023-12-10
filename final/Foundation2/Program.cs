using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        var addressUsa = new Address("456 Bright St", "Beville", "CA", "USA");
        var customerUsa = new Customer("Alice Smith", addressUsa);

        var product1 = new Product("Pencil", 123, 13.99, 2);
        var product2 = new Product("Paper", 345, 14.20, 1);

        var order1 = new Order(customerUsa, new List<Product> { product1, product2 });

        var addressInternational = new Address("789 Dark St", "Zion City", "Alberta", "Canada");
        var customerInternational = new Customer("Joseph Smith", addressInternational);

        var product3 = new Product("Ballpen", 323, 15.75, 3);
        var product4 = new Product("Notebook", 434, 10.75, 10);

        var order2 = new Order(customerInternational, new List<Product> { product3, product4 });

        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GeneratePackingLabel());

        Console.WriteLine("\nOrder 1 Shipping Label:");
        Console.WriteLine(order1.GenerateShippingLabel());

        Console.WriteLine($"\nOrder 1 Total Price: ${order1.CalculateTotalCost()}");

        Console.WriteLine("\n--------------------------\n");

        Console.WriteLine("Order 2 Packing Label:");
        Console.WriteLine(order2.GeneratePackingLabel());

        Console.WriteLine("\nOrder 2 Shipping Label:");
        Console.WriteLine(order2.GenerateShippingLabel());

        Console.WriteLine($"\nOrder 2 Total Price: ${order2.CalculateTotalCost()}");
    }
}
