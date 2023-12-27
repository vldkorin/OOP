using CourseWorkShop.Entity;

namespace CourseWorkShop.Repository;

public interface IPurchaseRepository
{
    public int Add(int productId, int customerId, int quantity, int price);
    public List<PurchaseEntity> GetAll();
    public PurchaseEntity GetById(int id);
    public List<PurchaseEntity> GetByCustomerId(int customerId);
    public List<PurchaseEntity> GetByProductId(int productId);
    public void Update(PurchaseEntity purchaseEntity);
    public void Delete(PurchaseEntity purchaseEntity);
    public void Delete(int id);
}