using CourseWorkShop.Customer;
using CourseWorkShop.Service;

namespace CourseWorkShop.CommandHandler;

public class ShowProductsCommand : ICommandHandler
{
    private readonly IProductService _productService;

    public ShowProductsCommand(IProductService productService)
    {
        _productService = productService;
    }

    public void ExecuteCommand()
    {
        var products = _productService.GetAvailable();
        foreach (var product in products) Console.WriteLine(product);
    }

    public string ShowInfo()
    {
        return "Show products";
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