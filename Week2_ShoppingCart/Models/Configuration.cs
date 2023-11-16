using System;
using System.Collections.Generic;

namespace Week2_ShoppingCart.Models;

public partial class Configuration
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Key { get; set; } = null!;

    public string Value { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid? Configurationgroupid { get; set; }

    public int Order { get; set; }

    public DateTime ModifiedOn { get; set; }

    public virtual ConfigurationGroup? Configurationgroup { get; set; }
}
