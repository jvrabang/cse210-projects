using System.Collections.Generic;
using System.Text; 

public class Order
{
    private Customer _customer;
    private List<Product> _products;

    public Order(Customer customer, List<Product> products)
    {
        _customer = customer;
        _products = products;
    }

    public double CalculateTotalCost()
    {
        double totalCost = _products.Sum(product => product.GetPrice());
        double shippingCost = _customer.IsUsaCustomer() ? 5 : 35;
        return totalCost + shippingCost;
    }

    public string GeneratePackingLabel()
    {
        var packingLabel = new StringBuilder();
        foreach (var product in _products)
        {
            packingLabel.AppendLine($"{product.GetName()} (ID: {product.GetProductId()})");
        }
        return packingLabel.ToString();
    }

    public string GenerateShippingLabel()
    {
        var customerName = _customer.GetName();
        var customerAddress = _customer.GetAddress().GetFullAddress();
        return $"Ship to:\n{customerName}\n{customerAddress}";
    }
}
