using CourseWorkShop.Customer;
using CourseWorkShop.Entity;
using CourseWorkShop.Enums;

namespace CourseWorkShop.Mapper;

public static class CustomerMapper
{
    public static CustomerEntity Map(ICustomer customer)
    {
        return new CustomerEntity
        {
            Id = customer.Id,
            Email = customer.Email,
            Discount = customer.Discount,
            Balance = customer.Balance,
            Type = customer.Type.ToString()
        };
    }

    public static ICustomer Map(CustomerEntity customerEntity)
    {
        Enum.TryParse<CustomerType>(customerEntity.Type, out var customerType);
        return customerType switch
        {
            CustomerType.Standard => new StandardCustomer
            {
                Id = customerEntity.Id,
                Email = customerEntity.Email,
                Discount = customerEntity.Discount,
                Balance = customerEntity.Balance
            },
            CustomerType.Premium => new PremiumCustomer
            {
                Id = customerEntity.Id,
                Email = customerEntity.Email,
                Discount = customerEntity.Discount,
                Balance = customerEntity.Balance
            },
            _ => throw new Exception("Customer type not found")
        };
    }
}