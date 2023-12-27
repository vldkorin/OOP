namespace CourseWorkShop.Purchase;

public interface IPurchase
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
    public int TotalPrice();
}