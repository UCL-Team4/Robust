﻿using Robust.Enums.Category;

namespace Robust.Model.Product;

public class Product
{
    public int ProductID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string ImagePath { get; set; }

    public Category Category { get; set; }
}