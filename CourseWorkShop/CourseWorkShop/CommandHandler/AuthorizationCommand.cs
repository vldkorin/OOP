using CourseWorkShop.Customer;
using CourseWorkShop.Enums;
using CourseWorkShop.Service;

namespace CourseWorkShop.CommandHandler;

public class AuthorizationCommand : ICommandHandler
{
    private readonly ICustomerService _customerService;
    private ICustomer? _customer;

    public AuthorizationCommand(ICustomerService customerService, Func<ICustomer, bool> saveCustomer)
    {
        _customerService = customerService;
        SaveCustomer = saveCustomer;
    }

    private Func<ICustomer, bool> SaveCustomer { get; }

    public void ExecuteCommand()
    {
        Console.Write("Enter your choice (0 - Login, 1 - Register): ");
        int choice;
        do
        {
            choice = int.Parse(Console.ReadLine() ?? string.Empty);
        } while (choice != 0 && choice != 1);

        if (choice == 0)
            Login();
        else
            Register();
        if (_customer != null) SaveCustomer(_customer);
    }

    public string ShowInfo()
    {
        return "Authorization";
    }

    public bool IsNeedCustomer()
    {
        return false;
    }

    public void SetCustomer(ICustomer customer)
    {
        throw new NotImplementedException();
    }

    private void Login()
    {
        Console.Write("Enter your email: ");
        var email = Console.ReadLine();
        _customer = _customerService.GetByEmail(email ?? string.Empty);
        Console.WriteLine("You are logged in");
    }

    private void Register()
    {
        Console.Write("Enter your email: ");
        var email = Console.ReadLine();

        Console.Write("Enter your balance: ");
        int balance;
        do
        {
            balance = int.Parse(Console.ReadLine() ?? string.Empty);
        } while (balance < 0);

        Console.Write("Enter your type (0 - Standard, 1 - Premium): ");
        int typeChoice;
        do
        {
            typeChoice = int.Parse(Console.ReadLine() ?? string.Empty);
        } while (typeChoice != 0 && typeChoice != 1);

        int discount = 0;
        if (typeChoice == 1)
        {
            Console.Write("Enter your discount: ");
            do
            {
                discount = int.Parse(Console.ReadLine() ?? string.Empty);
            } while (discount < 0 || discount > 100);
        }

        var type = typeChoice == 0 ? CustomerType.Standard : CustomerType.Premium;
        _customer = _customerService.Add(email ?? string.Empty, discount, balance, type);
        Console.WriteLine("You are registered");
    }
}