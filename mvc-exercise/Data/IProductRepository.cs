using mvc_exercise.Models;

namespace mvc_exercise.Data;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllProducts();
}