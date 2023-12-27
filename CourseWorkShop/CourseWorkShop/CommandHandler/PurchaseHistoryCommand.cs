using CourseWorkShop.Customer;
using CourseWorkShop.Service;

namespace CourseWorkShop.CommandHandler;

public class PurchaseHistoryCommand : ICommandHandler
{
    private readonly IPurchaseService _purchaseService;
    private ICustomer? _customer;

    public PurchaseHistoryCommand(IPurchaseService purchaseService)
    {
        _purchaseService = purchaseService;
    }

    public void ExecuteCommand()
    {
        if (_customer == null)
        {
            Console.WriteLine("You are not logged in");
            return;
        }

        var purchases = _purchaseService.GetByCustomerId(_customer.Id);
        foreach (var purchase in purchases) Console.WriteLine(purchase);
    }

    public string ShowInfo()
    {
        return "Show purchase history";
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