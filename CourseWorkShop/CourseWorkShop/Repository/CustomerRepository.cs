using CourseWorkShop.DataBase;
using CourseWorkShop.Entity;

namespace CourseWorkShop.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly DbContext _dbContext;

    public CustomerRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int Add(string email, int discount, int balance, string type)
    {
        int id;
        if (_dbContext.Customers.Count == 0)
            id = 1;
        else
            id = _dbContext.Customers.Max(customer => customer.Id) + 1;
        _dbContext.Customers.Add(new CustomerEntity
        {
            Id = id,
            Email = email,
            Discount = discount,
            Balance = balance,
            Type = type
        });
        return id;
    }

    public List<CustomerEntity> GetAll()
    {
        return _dbContext.Customers;
    }

    public CustomerEntity GetById(int id)
    {
        return _dbContext.Customers.FirstOrDefault(customer => customer.Id == id) ??
               throw new Exception("Customer not found");
    }

    public CustomerEntity GetByEmail(string email)
    {
        return _dbContext.Customers.FirstOrDefault(customer => customer.Email == email) ??
               throw new Exception("Customer not found");
    }

    public void Update(CustomerEntity customerEntity)
    {
        var index = _dbContext.Customers.FindIndex(customer => customer.Id == customerEntity.Id);
        if (index == -1) throw new Exception("Customer not found");
        _dbContext.Customers[index] = customerEntity;
    }

    public void Delete(CustomerEntity customerEntity)
    {
        Delete(customerEntity.Id);
    }

    public void Delete(int id)
    {
        var index = _dbContext.Customers.FindIndex(customer => customer.Id == id);
        if (index == -1) throw new Exception("Customer not found");
        _dbContext.Customers.RemoveAt(index);
        _dbContext.Purchases.RemoveAll(purchase => purchase.CustomerId == id);
    }
}