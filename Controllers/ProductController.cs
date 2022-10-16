using Microsoft.AspNetCore.Mvc;
using demo.Services;
using demo.Models;

namespace demo.Controllers
{
  public class ProductController : Controller
  {
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
      _productService = productService;
    }

    public IActionResult Index()
    {
      var products = _productService.GetProducts();
      return View(products);
    }

    public IActionResult Create()
    {
      var categories = _productService.GetCategories();
      return View(categories);
    }

    public IActionResult Save(Product product)
    {
      if (product.Id == 0)
      {
        _productService.CreateProduct(product);
        return RedirectToAction("Index");
      }
      _productService.UpdateProduct(product);
      return RedirectToAction("Index");
    }

    public IActionResult Detail(int id)
    {
      var product = _productService.GetProduct(id);
      return View(product);
    }

    public IActionResult Update(int id)
    {
      var product = _productService.GetProduct(id);
      if (product == null)
      {
        return RedirectToAction("Create");
      }
      var categories = _productService.GetCategories();
      ViewBag.Product = product;

      return View(categories);
    }

    public IActionResult Delete(int id)
    {
      _productService.DeleteProduct(id);
      return RedirectToAction("Index");
    }
  }
}