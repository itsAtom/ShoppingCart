using System;
using System.Collections.Generic;

namespace Week2_ShoppingCart.Models;

public partial class ProductsAttribute
{
    public Guid Id { get; set; }

    public Guid? Productsid { get; set; }

    public Guid? Optionsid { get; set; }

    public Guid? Optionvaluesid { get; set; }

    public decimal Price { get; set; }

    public string PricePrefix { get; set; } = null!;

    public virtual ProductsOption? Options { get; set; }

    public virtual ProductsOptionsValue? Optionvalues { get; set; }

    public virtual Product? Products { get; set; }
}
