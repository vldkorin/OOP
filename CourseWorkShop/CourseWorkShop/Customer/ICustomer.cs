using CourseWorkShop.Enums;

namespace CourseWorkShop.Customer;

public interface ICustomer
{
    public int Id { get; set; }
    public string Email { get; set; }
    public int Discount { get; set; }
    public int Balance { get; set; }
    public CustomerType Type { get; set; }

    public void AddToBalance(int amount);
    public void Buy(int amount);
    public bool CanBuy(int amount);
}