using CourseWorkShop.Entity;

namespace CourseWorkShop.DataBase;

public class DbContext
{
    public readonly List<CustomerEntity> Customers = new();

    public readonly List<ProductEntity> Products = new()
    {
        new ProductEntity() { Id = 1, Name = "Apple", Price = 10, Quantity = 100 },
        new ProductEntity() { Id = 2, Name = "Banana", Price = 20, Quantity = 10 },
        new ProductEntity() { Id = 3, Name = "Orange", Price = 30, Quantity = 20 }
    };

    public readonly List<PurchaseEntity> Purchases = new();
}