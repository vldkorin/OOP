using CourseWorkShop.Entity;
using CourseWorkShop.Purchase;

namespace CourseWorkShop.Mapper;

public static class PurchaseMapper
{
    public static PurchaseEntity Map(IPurchase purchase)
    {
        return new PurchaseEntity
        {
            Id = purchase.Id,
            CustomerId = purchase.CustomerId,
            ProductId = purchase.ProductId,
            Quantity = purchase.Quantity,
            Price = purchase.Price
        };
    }

    public static IPurchase Map(PurchaseEntity purchaseEntity)
    {
        return new Purchase.Purchase
        {
            Id = purchaseEntity.Id,
            CustomerId = purchaseEntity.CustomerId,
            ProductId = purchaseEntity.ProductId,
            Quantity = purchaseEntity.Quantity,
            Price = purchaseEntity.Price
        };
    }
}