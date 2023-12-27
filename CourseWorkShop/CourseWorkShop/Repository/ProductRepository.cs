using CourseWorkShop.DataBase;
using CourseWorkShop.Entity;

namespace CourseWorkShop.Repository;

public class ProductRepository : IProductRepository
{
    private readonly DbContext _dbContext;

    public ProductRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int Add(string name, int price, int quantity)
    {
        int id;
        if (_dbContext.Products.Count == 0)
            id = 1;
        else
            id = _dbContext.Products.Max(product => product.Id) + 1;
        _dbContext.Products.Add(new ProductEntity
        {
            Id = id,
            Name = name,
            Price = price,
            Quantity = quantity
        });
        return id;
    }

    public List<ProductEntity> GetAll()
    {
        return _dbContext.Products;
    }

    public List<ProductEntity> GetAvailable()
    {
        return _dbContext.Products.Where(product => product.Quantity > 0).ToList();
    }

    public ProductEntity GetById(int id)
    {
        return _dbContext.Products.FirstOrDefault(product => product.Id == id) ??
               throw new Exception("Product not found");
    }

    public void Update(ProductEntity productEntity)
    {
        var index = _dbContext.Products.FindIndex(product => product.Id == productEntity.Id);
        if (index == -1) throw new Exception("Product not found");
        _dbContext.Products[index] = productEntity;
    }

    public void Delete(ProductEntity productEntity)
    {
        Delete(productEntity.Id);
    }

    public void Delete(int id)
    {
        var index = _dbContext.Products.FindIndex(product => product.Id == id);
        if (index == -1) throw new Exception("Product not found");
        _dbContext.Products.RemoveAt(index);
        _dbContext.Purchases.RemoveAll(purchase => purchase.ProductId == id);
    }
}