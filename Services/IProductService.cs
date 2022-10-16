using demo.Models;

namespace demo.Services
{
  public interface IProductService
  {
    // Product
    List<Product> GetProducts();
    Product? GetProduct(int id);
    void CreateProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int id);

    // Category
    List<Category> GetCategories();
  }
}