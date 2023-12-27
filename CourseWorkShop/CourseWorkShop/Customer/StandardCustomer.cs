using CourseWorkShop.Enums;

namespace CourseWorkShop.Customer;

public class StandardCustomer : ICustomer
{
    public int Id { get; set; }
    public string Email { get; set; }
    public int Discount { get; set; }
    public int Balance { get; set; }
    public CustomerType Type { get; set; }

    public void AddToBalance(int amount)
    {
        Balance += amount;
    }

    public void Buy(int amount)
    {
        Balance -= amount;
    }

    public bool CanBuy(int amount)
    {
        return Balance >= amount;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Email: {Email}, Discount: {Discount}, Balance: {Balance}, Type: {Type}";
    }
}