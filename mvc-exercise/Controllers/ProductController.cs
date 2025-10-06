using Microsoft.AspNetCore.Mvc;
using mvc_exercise.Data;
using mvc_exercise.Models;

namespace mvc_exercise.Controllers;

public class ProductController : Controller
{
    
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }
    // GET
    public IActionResult Index()
    {
        var products = _repository.GetAllProducts();
        return View(products);
    }

    public IActionResult ViewProduct(int id)
    {
        var product = _repository.GetProduct(id);
        return View(product);
    }
    
    public IActionResult UpdateProduct(int id)
    {
        var product = _repository.GetProduct(id);
        if (product == null)
        {
            return View("ProductNotFound");
        }
        return View(product);
    }
    
    
    public IActionResult UpdateProductToDatabase(Product product)
    {
        _repository.UpdateProduct(product);

        return RedirectToAction("ViewProduct", new { id = product.ProductId });
    }
    
    public IActionResult InsertProduct()
    {
        var product = _repository.AssignCategory();
        return View(product);
    }
    
    public IActionResult InsertProductToDatabase(Product productToInsert)
    {
        _repository.InsertProduct(productToInsert);
        return RedirectToAction("Index");
    }
    
    public IActionResult DeleteProduct(Product product)
    {
        _repository.DeleteProduct(product);
        return RedirectToAction("Index");
    }
}