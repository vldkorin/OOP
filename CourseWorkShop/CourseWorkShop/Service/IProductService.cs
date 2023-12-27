using CourseWorkShop.Product;

namespace CourseWorkShop.Service;

public interface IProductService
{
    public int Add(string name, int price, int quantity);
    public List<IProduct> GetAll();
    public List<IProduct> GetAvailable();
    public IProduct GetById(int id);
    public void Update(IProduct product);
    public void Delete(IProduct product);
    public void Delete(int id);
}