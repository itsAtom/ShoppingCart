using System;
using System.Collections.Generic;

namespace Week2_ShoppingCart.Models;

public partial class ProductsOptionsValuesMapping
{
    public Guid Id { get; set; }

    public Guid? Optionsid { get; set; }

    public Guid? Valuesid { get; set; }

    public virtual ProductsOption? Options { get; set; }

    public virtual ProductsOptionsValue? Values { get; set; }
}
