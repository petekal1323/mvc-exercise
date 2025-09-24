using System.Data;
using mvc_exercise.Models;
using Dapper;

namespace mvc_exercise.Data;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _connection;


    public ProductRepository(IDbConnection connection)
    {
        _connection = connection;
    }
        
    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM products");
    }

    public Product GetProduct(int id)
    {
        return _connection.QuerySingle<Product>("SELECT * FROM products WHERE ProductID = @id", new { id });
    }
}