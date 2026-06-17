using Microsoft.AspNetCore.Mvc;
using Practice.Api.Models;
using Practice.Api.Repositories;

namespace Practice.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductRepository _repository;

    public ProductsController(ProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _repository.GetAllProducts();

        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(
        [FromBody] CreateProductRequest request)
    {
        var rows = await _repository.AddProduct(
            request.ProductName,
            request.Description);

        return Ok(new
        {
            RowsAffected = rows
        });
    }
}