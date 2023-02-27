﻿namespace Newtech.Data.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImageURL { get; set; } = null!;
    public decimal Price { get; set; }
    public int Qty { get; set; }
    public int ProductCategoryId { get; set; }
    public ProductCategory? ProductCategory { get; set; }
}
