using CourseWorkShop.Entity;
using CourseWorkShop.Product;

namespace CourseWorkShop.Mapper;

public static class ProductMapper
{
    public static ProductEntity Map(IProduct product)
    {
        return new ProductEntity
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Quantity = product.Quantity
        };
    }

    public static IProduct Map(ProductEntity productEntity)
    {
        return new Product.Product
        {
            Id = productEntity.Id,
            Name = productEntity.Name,
            Price = productEntity.Price,
            Quantity = productEntity.Quantity
        };
    }
}