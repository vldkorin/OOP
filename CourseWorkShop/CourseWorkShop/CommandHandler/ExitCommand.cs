using CourseWorkShop.Customer;

namespace CourseWorkShop.CommandHandler;

public class ExitCommand : ICommandHandler
{
    public void ExecuteCommand()
    {
        Console.WriteLine("Close program");
        Environment.Exit(0);
    }

    public string ShowInfo()
    {
        return "Exit";
    }

    public bool IsNeedCustomer()
    {
        return false;
    }

    public void SetCustomer(ICustomer customer)
    {
        throw new NotImplementedException();
    }
}

