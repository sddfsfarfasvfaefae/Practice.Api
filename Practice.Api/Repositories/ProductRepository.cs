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
}