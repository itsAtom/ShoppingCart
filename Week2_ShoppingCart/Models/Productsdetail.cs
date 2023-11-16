using System;
using System.Collections.Generic;

namespace Week2_ShoppingCart.Models;

public partial class Productsdetail
{
    public Guid Id { get; set; }

    public Guid? Productid { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Url { get; set; } = null!;

    public int Views { get; set; }

    public virtual Product? Product { get; set; }
}
