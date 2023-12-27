using CourseWorkShop.Customer;
using CourseWorkShop.Service;

namespace CourseWorkShop.CommandHandler;

public class BuyProductCommand : ICommandHandler
{
    private readonly IProductService _productService;
    private readonly IPurchaseService _purchaseService;
    private ICustomer? _customer;

    public BuyProductCommand(IProductService productService, IPurchaseService purchaseService)
    {
        _productService = productService;
        _purchaseService = purchaseService;
    }

    public void ExecuteCommand()
    {
        if (_customer == null)
        {
            Console.WriteLine("You must login first");
            return;
        }

        var products = _productService.GetAvailable();
        foreach (var p in products) Console.WriteLine(p);

        Console.Write("Enter product id: ");
        int productId;
        do
        {
            productId = int.Parse(Console.ReadLine() ?? string.Empty);
        } while (products.FindIndex(p => p.Id == productId).Equals(-1));

        var product = _productService.GetById(productId);

        Console.Write("Enter quantity: ");
        int quantity;
        do
        {
            quantity = int.Parse(Console.ReadLine() ?? string.Empty);
        } while (quantity <= 0 || product.Quantity < quantity);

        _purchaseService.Add(productId, _customer.Id, quantity, product.Price);

        Console.WriteLine("Product is bought successfully");
    }

    public string ShowInfo()
    {
        return "Buy product";
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