public class Product
{
    private string _name;
    private int _product_id;
    private double _price;
    private int _quantity;

    public Product(string name, int productId, double price, int quantity)
    {
        _name = name;
        _product_id = productId;
        _price = price;
        _quantity = quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetProductId()
    {
        return _product_id;
    }

    public double GetPrice()
    {
        return _price * _quantity;
    }
}
