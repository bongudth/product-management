using demo.Models;
using Microsoft.EntityFrameworkCore;

namespace demo.Services
{
  public class ProductService : IProductService
  {
    private readonly DataContext _context;

    public ProductService(DataContext context)
    {
      _context = context;
    }

    public void CreateProduct(Product product)
    {
      _context.Products.Add(product);
      _context.SaveChanges();
    }

    public void DeleteProduct(int id)
    {
      var existedProduct = GetProduct(id);
      if (existedProduct == null) return;
      _context.Products.Remove(existedProduct);
      _context.SaveChanges();
    }

    public List<Product> GetProducts()
    {
      return _context.Products.Include(p => p.Category).ToList();
    }

    public Product? GetProduct(int id)
    {
      return _context.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
    }

    public void UpdateProduct(Product product)
    {
      var existedProduct = GetProduct(product.Id);
      if (existedProduct == null) return;
      _context.Products.Update(product);
      _context.SaveChanges();
    }

    public List<Category> GetCategories()
    {
      return _context.Categories.ToList();
    }
  }
}