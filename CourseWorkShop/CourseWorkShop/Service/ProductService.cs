using CourseWorkShop.Mapper;
using CourseWorkShop.Product;
using CourseWorkShop.Repository;

namespace CourseWorkShop.Service;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public int Add(string name, int price, int quantity)
    {
        return _productRepository.Add(name, price, quantity);
    }

    public List<IProduct> GetAll()
    {
        return _productRepository.GetAll().Select(ProductMapper.Map).ToList();
    }

    public List<IProduct> GetAvailable()
    {
        return _productRepository.GetAvailable().Select(ProductMapper.Map).ToList();
    }

    public IProduct GetById(int id)
    {
        return ProductMapper.Map(_productRepository.GetById(id));
    }

    public void Update(IProduct product)
    {
        _productRepository.Update(ProductMapper.Map(product));
    }

    public void Delete(IProduct product)
    {
        _productRepository.Delete(ProductMapper.Map(product));
    }

    public void Delete(int id)
    {
        _productRepository.Delete(id);
    }
}