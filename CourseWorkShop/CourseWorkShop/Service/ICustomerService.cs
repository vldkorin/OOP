using CourseWorkShop.Customer;
using CourseWorkShop.Enums;

namespace CourseWorkShop.Service;

public interface ICustomerService
{
    public ICustomer Add(string email, int discount, int balance, CustomerType type);
    public List<ICustomer> GetAll();
    public ICustomer GetById(int id);
    public ICustomer GetByEmail(string email);
    public void Update(ICustomer customer);
    public void Delete(ICustomer customer);
    public void Delete(int id);
    public int AddPurchase(int customerId, int productId, int quantity);
}