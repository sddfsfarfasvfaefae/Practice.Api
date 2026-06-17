namespace Practice.Api.Models;

public class CreateProductRequest
{
    public string ProductName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}