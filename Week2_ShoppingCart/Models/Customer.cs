﻿using System;
using System.Collections.Generic;

namespace Week2_ShoppingCart.Models;

public partial class Customer
{
    public Guid Id { get; set; }

    public string Gender { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string Email { get; set; } = null!;

    public Guid? Mainaddressid { get; set; }

    public string Telephone { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Newsletteropted { get; set; }

    public virtual ICollection<AddressBook> AddressBooks { get; set; } = new List<AddressBook>();

    public virtual ICollection<CartAttribute> CartAttributes { get; set; } = new List<CartAttribute>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<CustomerInfo> CustomerInfos { get; set; } = new List<CustomerInfo>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
