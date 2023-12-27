using CourseWorkShop.Entity;

namespace CourseWorkShop.Repository;

public interface IProductRepository
{
    public int Add(string name, int price, int quantity);
    public List<ProductEntity> GetAll();
    public List<ProductEntity> GetAvailable();
    public ProductEntity GetById(int id);
    public void Update(ProductEntity productEntity);
    public void Delete(ProductEntity productEntity);
    public void Delete(int id);
}