namespace CourseWorkShop.Product;

public class Product : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }

    public void Buy(int quantity)
    {
        Quantity -= quantity;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Price: {Price}, Quantity: {Quantity}";
    }
}