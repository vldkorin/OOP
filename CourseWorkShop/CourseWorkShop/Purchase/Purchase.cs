namespace CourseWorkShop.Purchase;

public class Purchase : IPurchase
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }

    public int TotalPrice()
    {
        return Quantity * Price;
    }

    public override string ToString()
    {
        return $"Id: {Id}, ProductId: {ProductId}, CustomerId: {CustomerId}, Quantity: {Quantity}, Price: {Price}";
    }
}