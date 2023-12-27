using CourseWorkShop.CommandHandler;
using CourseWorkShop.Customer;
using CourseWorkShop.DataBase;
using CourseWorkShop.Repository;
using CourseWorkShop.Service;

namespace CourseWorkShop.Program;

internal class Program
{
    private static List<ICommandHandler> CreateCommands(ICustomerService customerService,
        IProductService productService,
        IPurchaseService purchaseService,
        Func<ICustomer, bool> saveCustomer)
    {
        var commands = new List<ICommandHandler>
        {
            new ExitCommand(),
            new AuthorizationCommand(customerService, saveCustomer),
            new ShowProductsCommand(productService),
            new BuyProductCommand(productService, purchaseService),
            new PurchaseHistoryCommand(purchaseService),
            new TopUpBalanceCommand(customerService)
        };
        return commands;
    }
   
    private static void Run(List<ICommandHandler> commands, ICustomer? customer)
    {
        if (customer != null)
            Console.WriteLine($"\nYou are logged in as\n{customer}\n");
        var availableCommands = commands
            .Where(c => !c.IsNeedCustomer() || customer != null).ToList();
        Console.WriteLine("Choose command\nAll commands:");
        for (var i = 0; i < availableCommands.Count(); i++)
            Console.WriteLine($"{i + 1}-Command {availableCommands[i].ShowInfo()}");
        Console.Write("> ");

        int choice;
        do
        {
            choice = int.Parse(Console.ReadLine() ?? string.Empty);
        } while (choice < 1 || choice > availableCommands.Count());

        var command = availableCommands[choice - 1];
        if (command.IsNeedCustomer())
            if (customer != null)
                command.SetCustomer(customer);
            else
                Console.WriteLine("You are not logged in");

        try
        {
            command.ExecuteCommand();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void Main()
    {
        var dbContext = new DbContext();
        var customerRepository = new CustomerRepository(dbContext);
        var productRepository = new ProductRepository(dbContext);
        var purchaseRepository = new PurchaseRepository(dbContext);
        var customerService = new CustomerService(customerRepository, purchaseRepository, productRepository);
        var productService = new ProductService(productRepository);
        var purchaseService = new PurchaseService(purchaseRepository, customerRepository, productRepository);

        int? customerId = null;

        bool SaveCustomer(ICustomer c)
        {
            customerId = c.Id;
            return true;
        }

        var commands = CreateCommands(customerService, productService, purchaseService, SaveCustomer);
        while (true)
        {
            var customer = customerId != null ? customerService.GetById(customerId.Value) : null;
            Run(commands, customer);
        }
    }
}