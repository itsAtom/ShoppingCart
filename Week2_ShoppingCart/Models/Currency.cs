using System;
using System.Collections.Generic;

namespace Week2_ShoppingCart.Models;

public partial class Currency
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string? Symboleleft { get; set; }

    public string? Symbolright { get; set; }

    public virtual ICollection<Country> Countries { get; set; } = new List<Country>();
}
