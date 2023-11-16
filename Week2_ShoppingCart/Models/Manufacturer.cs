using System;
using System.Collections.Generic;

namespace Week2_ShoppingCart.Models;

public partial class Manufacturer
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Image { get; set; } = null!;

    public virtual ICollection<ManufacturersInfo> ManufacturersInfos { get; set; } = new List<ManufacturersInfo>();
}
