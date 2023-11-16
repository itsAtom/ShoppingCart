using System;
using System.Collections.Generic;

namespace Week2_ShoppingCart.Models;

public partial class ManufacturersInfo
{
    public Guid Id { get; set; }

    public Guid? Manufacturerid { get; set; }

    public string Url { get; set; } = null!;

    public DateTime Addedon { get; set; }

    public virtual Manufacturer? Manufacturer { get; set; }
}
