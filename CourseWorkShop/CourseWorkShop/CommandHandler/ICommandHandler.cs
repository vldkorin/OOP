using CourseWorkShop.Customer;

namespace CourseWorkShop.CommandHandler;

public interface ICommandHandler
{
    void ExecuteCommand();
    string ShowInfo();
    bool IsNeedCustomer();
    void SetCustomer(ICustomer customer);
}