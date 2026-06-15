using System.Data;
using Npgsql;

namespace Practice.Api.Data;

public class DapperContext
{
    private readonly IConfiguration _configuration;

    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(
            _configuration.GetConnectionString("DefaultConnection"));
    }
}