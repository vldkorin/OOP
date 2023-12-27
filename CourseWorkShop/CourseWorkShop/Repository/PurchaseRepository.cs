using CourseWorkShop.DataBase;
using CourseWorkShop.Entity;

namespace CourseWorkShop.Repository;

public class PurchaseRepository : IPurchaseRepository
{
    private readonly DbContext _dbContext;

    public PurchaseRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int Add(int productId, int customerId, int quantity, int price)
    {
        int id;
        if (_dbContext.Purchases.Count == 0)
            id = 1;
        else
            id = _dbContext.Purchases.Max(purchase => purchase.Id) + 1;
        _dbContext.Purchases.Add(new PurchaseEntity
        {
            Id = id,
            ProductId = productId,
            CustomerId = customerId,
            Quantity = quantity,
            Price = price
        });
        return id;
    }

    public List<PurchaseEntity> GetAll()
    {
        return _dbContext.Purchases;
    }

    public PurchaseEntity GetById(int id)
    {
        return _dbContext.Purchases.FirstOrDefault(purchase => purchase.Id == id) ??
               throw new Exception("Purchase not found");
    }

    public List<PurchaseEntity> GetByCustomerId(int customerId)
    {
        return _dbContext.Purchases.Where(purchase => purchase.CustomerId == customerId).ToList();
    }

    public List<PurchaseEntity> GetByProductId(int productId)
    {
        return _dbContext.Purchases.Where(purchase => purchase.ProductId == productId).ToList();
    }

    public void Update(PurchaseEntity purchaseEntity)
    {
        var index = _dbContext.Purchases.FindIndex(purchase => purchase.Id == purchaseEntity.Id);
        if (index == -1) throw new Exception("Purchase not found");
        _dbContext.Purchases[index] = purchaseEntity;
    }

    public void Delete(PurchaseEntity purchaseEntity)
    {
        Delete(purchaseEntity.Id);
    }

    public void Delete(int id)
    {
        var index = _dbContext.Purchases.FindIndex(purchase => purchase.Id == id);
        if (index == -1) throw new Exception("Purchase not found");
        _dbContext.Purchases.RemoveAt(index);
    }
}