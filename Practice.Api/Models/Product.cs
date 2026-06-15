namespace Practice.Api.Models;

public class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public string ManufacturerName { get; set; } = string.Empty;
    public string SupplierName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
}