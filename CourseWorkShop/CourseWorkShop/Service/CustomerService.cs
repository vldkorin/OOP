using CourseWorkShop.Customer;
using CourseWorkShop.Enums;
using CourseWorkShop.Mapper;
using CourseWorkShop.Repository;

namespace CourseWorkShop.Service;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IProductRepository _productRepository;
    private readonly IPurchaseRepository _purchaseRepository;

    public CustomerService(ICustomerRepository customerRepository, IPurchaseRepository purchaseRepository,
        IProductRepository productRepository)
    {
        _customerRepository = customerRepository;
        _purchaseRepository = purchaseRepository;
        _productRepository = productRepository;
    }

    public ICustomer Add(string email, int discount, int balance, CustomerType type)
    {
        var id = _customerRepository.Add(email, discount, balance, type.ToString());
        return GetById(id);
    }

    public List<ICustomer> GetAll()
    {
        return _customerRepository.GetAll().Select(CustomerMapper.Map).ToList();
    }

    public ICustomer GetById(int id)
    {
        return CustomerMapper.Map(_customerRepository.GetById(id));
    }

    public ICustomer GetByEmail(string email)
    {
        return CustomerMapper.Map(_customerRepository.GetByEmail(email));
    }

    public void Update(ICustomer customer)
    {
        _customerRepository.Update(CustomerMapper.Map(customer));
    }

    public void Delete(ICustomer customer)
    {
        _customerRepository.Delete(CustomerMapper.Map(customer));
    }

    public void Delete(int id)
    {
        _customerRepository.Delete(id);
    }

    public int AddPurchase(int customerId, int productId, int quantity)
    {
        var productEntity = _productRepository.GetById(productId);
        var customerEntity = _customerRepository.GetById(customerId);
        var purchaseId = _purchaseRepository.Add(productId, customerId, quantity, productEntity.Price);
        var purchaseEntity = _purchaseRepository.GetById(purchaseId);
        var purchase = PurchaseMapper.Map(purchaseEntity);
        var customer = CustomerMapper.Map(customerEntity);
        customer.Buy(purchase.TotalPrice());
        return purchaseId;
    }
}