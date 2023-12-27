using CourseWorkShop.Entity;

namespace CourseWorkShop.Repository;

public interface ICustomerRepository
{
    public int Add(string email, int discount, int balance, string type);
    public List<CustomerEntity> GetAll();
    public CustomerEntity GetById(int id);
    public CustomerEntity GetByEmail(string email);
    public void Update(CustomerEntity customerEntity);
    public void Delete(CustomerEntity customerEntity);
    public void Delete(int id);
}