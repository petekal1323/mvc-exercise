using Microsoft.AspNetCore.Mvc;
using mvc_exercise.Data;

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
}