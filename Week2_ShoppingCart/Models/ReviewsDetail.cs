using System;
using System.Collections.Generic;

namespace Week2_ShoppingCart.Models;

public partial class ReviewsDetail
{
    public Guid Id { get; set; }

    public Guid? Reviewid { get; set; }

    public string Text { get; set; } = null!;

    public virtual Review? Review { get; set; }
}
