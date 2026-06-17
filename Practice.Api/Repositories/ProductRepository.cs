using Dapper;
using Practice.Api.Data;
using Practice.Api.Models;

namespace Practice.Api.Repositories;

public class ProductRepository
{
    private readonly DapperContext _context;

    public ProductRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        const string sql =
            "SELECT * FROM vw_products_full";

        using var connection =
            _context.CreateConnection();

        return await connection.QueryAsync<Product>(sql);
    }

    public async Task<int> AddProduct(
        string productName,
        string description)
    {
        const string sql = @"
INSERT INTO products
(
    product_name,
    category_id,
    manufacturer_id,
    supplier_id,
    description,
    price,
    unit,
    stock_quantity
)
VALUES
(
    @ProductName,
    1,
    1,
    1,
    @Description,
    1000,
    'пара',
    10
);";

        using var connection =
            _context.CreateConnection();

        return await connection.ExecuteAsync(
            sql,
            new
            {
                ProductName = productName,
                Description = description
            });
    }
}