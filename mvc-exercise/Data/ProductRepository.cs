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

    public void UpdateProduct(Product product)
    {
        _connection.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @productID;",
            new { name = product.Name, price = product.Price, productID = product.ProductId });
    }

    public void InsertProduct(Product productToInsert)
    {
        _connection.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryId);",
            new {name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryId });
    }

    public IEnumerable<Category> GetCategories()
    {
        return _connection.Query<Category>("SELECT * FROM categories;");
    }

    public Product AssignCategory()
    {
        var categoryList = GetCategories();
        var product = new Product();
        product.Categories = categoryList;
        return product;
    } 
    
    public void DeleteProduct(Product product) 
    {
        _connection.Execute("DELETE FROM reviews WHERE ProductId = @id;", new {id = product.ProductId }); 
        _connection.Execute("DELETE FROM sales WHERE ProductId = @id;",  new { id = product.ProductId }); 
        _connection.Execute("DELETE FROM products WHERE ProductId = @id;", new { id = product.ProductId });
    }
    
}