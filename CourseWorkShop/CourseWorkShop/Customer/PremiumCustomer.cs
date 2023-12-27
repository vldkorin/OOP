using CourseWorkShop.Enums;

namespace CourseWorkShop.Customer;

public class PremiumCustomer : ICustomer
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
        Balance -= amount * (100 - Discount) / 100;
    }

    public bool CanBuy(int amount)
    {
        return Balance >= amount * (100 - Discount) / 100;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Email: {Email}, Discount: {Discount}, Balance: {Balance}, Type: {Type}";
    }
}