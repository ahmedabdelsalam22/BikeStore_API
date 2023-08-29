using System;
using System.Collections.Generic;

namespace BikeStore_API.Models;

public partial class ProductsInfo
{
    public string ProductName { get; set; } = null!;

    public string BrandName { get; set; } = null!;

    public decimal ListPrice { get; set; }
}
