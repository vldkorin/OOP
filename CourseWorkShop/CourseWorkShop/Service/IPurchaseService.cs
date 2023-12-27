using CourseWorkShop.Purchase;

namespace CourseWorkShop.Service;

public interface IPurchaseService
{
    public int Add(int productId, int customerId, int quantity, int price);
    public List<IPurchase> GetAll();
    public IPurchase GetById(int id);
    public List<IPurchase> GetByCustomerId(int customerId);
    public List<IPurchase> GetByProductId(int productId);
    public void Update(IPurchase purchase);
    public void Delete(IPurchase purchase);
    public void Delete(int id);
}