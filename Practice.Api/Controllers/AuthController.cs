using Microsoft.AspNetCore.Mvc;
using Practice.Api.Models;
using Practice.Api.Repositories;

namespace Practice.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserRepository _repository;

    public AuthController(UserRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var user = await _repository.Login(
            request.Login,
            request.Password);

        if (user == null)
        {
            return Unauthorized("Неверный логин или пароль");
        }

        return Ok(user);
    }
}