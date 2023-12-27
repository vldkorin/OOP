using CourseWorkShop.Mapper;
using CourseWorkShop.Purchase;
using CourseWorkShop.Repository;

namespace CourseWorkShop.Service;

public class PurchaseService : IPurchaseService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IProductRepository _productRepository;
    private readonly IPurchaseRepository _purchaseRepository;

    public PurchaseService(IPurchaseRepository purchaseRepository, ICustomerRepository customerRepository,
        IProductRepository productRepository)
    {
        _purchaseRepository = purchaseRepository;
        _customerRepository = customerRepository;
        _productRepository = productRepository;
    }

    public int Add(int productId, int customerId, int quantity, int price)
    {
        var customerEntity = _customerRepository.GetById(customerId);
        var productEntity = _productRepository.GetById(productId);
        var customer = CustomerMapper.Map(customerEntity);
        var product = ProductMapper.Map(productEntity);
        if (!customer.CanBuy(quantity * price))
            throw new Exception("Customer cannot buy this product");
        if (product.Quantity < quantity)
            throw new Exception("Not enough product in stock");
        var purchaseId = _purchaseRepository.Add(productId, customerId, quantity, price);
        var purchaseEntity = _purchaseRepository.GetById(purchaseId);
        var purchase = PurchaseMapper.Map(purchaseEntity);
        customer.Buy(purchase.TotalPrice());
        product.Buy(quantity);
        _customerRepository.Update(CustomerMapper.Map(customer));
        _productRepository.Update(ProductMapper.Map(product));
        return purchaseId;
    }

    public List<IPurchase> GetAll()
    {
        return _purchaseRepository.GetAll().Select(PurchaseMapper.Map).ToList();
    }

    public IPurchase GetById(int id)
    {
        return PurchaseMapper.Map(_purchaseRepository.GetById(id));
    }

    public List<IPurchase> GetByCustomerId(int customerId)
    {
        return _purchaseRepository.GetByCustomerId(customerId).Select(PurchaseMapper.Map).ToList();
    }

    public List<IPurchase> GetByProductId(int productId)
    {
        return _purchaseRepository.GetByProductId(productId).Select(PurchaseMapper.Map).ToList();
    }

    public void Update(IPurchase purchase)
    {
        _purchaseRepository.Update(PurchaseMapper.Map(purchase));
    }

    public void Delete(IPurchase purchase)
    {
        _purchaseRepository.Delete(PurchaseMapper.Map(purchase));
    }

    public void Delete(int id)
    {
        _purchaseRepository.Delete(id);
    }
}