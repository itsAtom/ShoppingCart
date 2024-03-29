﻿using System;
using System.Collections.Generic;

namespace Week2_ShoppingCart.Models;

public partial class CartAttribute
{
    public Guid Id { get; set; }

    public Guid? Customerid { get; set; }

    public Guid? Productid { get; set; }

    public Guid? Productoptionid { get; set; }

    public Guid? Productoptionvalueid { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ProductsOption? Productoption { get; set; }

    public virtual ProductsOptionsValue? Productoptionvalue { get; set; }
}
