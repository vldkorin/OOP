using CourseWorkShop.Customer;
using CourseWorkShop.Service;

namespace CourseWorkShop.CommandHandler;

public class TopUpBalanceCommand : ICommandHandler
{
    private readonly ICustomerService _customerService;
    private ICustomer? _customer;

    public TopUpBalanceCommand(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public void ExecuteCommand()
    {
        if (_customer == null)
        {
            Console.WriteLine("You are not logged in");
            return;
        }

        Console.Write("Enter amount: ");
        int amount;
        do
        {
            amount = int.Parse(Console.ReadLine() ?? string.Empty);
        } while (amount <= 0);

        _customer.Balance += amount;
        _customerService.Update(_customer);
        Console.WriteLine("Balance is topped up");
    }

    public string ShowInfo()
    {
        return "Top up balance";
    }

    public bool IsNeedCustomer()
    {
        return true;
    }

    public void SetCustomer(ICustomer customer)
    {
        _customer = customer;
    }
}