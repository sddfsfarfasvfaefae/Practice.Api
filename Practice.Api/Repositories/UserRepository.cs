using Dapper;
using Practice.Api.Data;
using Practice.Api.Models;

namespace Practice.Api.Repositories;

public class UserRepository
{
    private readonly DapperContext _context;

    public UserRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<LoginResponse?> Login(string login, string password)
    {
        var sql = @"
            SELECT
                u.user_id AS UserId,
                u.full_name AS FullName,
                r.role_name AS Role
            FROM users u
            JOIN roles r ON r.role_id = u.role_id
            WHERE u.login = @Login
            AND u.password = @Password";

        using var connection = _context.CreateConnection();

        return await connection.QueryFirstOrDefaultAsync<LoginResponse>(
            sql,
            new
            {
                Login = login,
                Password = password
            });
    }
}