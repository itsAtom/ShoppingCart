using System;
using System.Collections.Generic;

namespace Week2_ShoppingCart.Models;

public partial class Cart
{
    public Guid Id { get; set; }

    public Guid? Customerid { get; set; }

    public Guid? Productid { get; set; }

    public int Qty { get; set; }

    public decimal Finalprice { get; set; }

    public DateTime Addedon { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product? Product { get; set; }
}
