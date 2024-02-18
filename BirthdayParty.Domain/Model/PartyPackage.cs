﻿using System;
using System.Collections.Generic;

namespace BirthdayParty.Infrastructure.Model;

public partial class PartyPackage
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Location { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? AvailableDates { get; set; }

    public Guid? HostPartyId { get; set; }

    public string? Status { get; set; }

    public int? Price { get; set; }

    public Guid? DiscountId { get; set; }

    public bool? AvailableForPreorder { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Discount? Discount { get; set; }

    public virtual HostParty? HostParty { get; set; }

    public virtual ICollection<Menu> Menus { get; } = new List<Menu>();

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

    public virtual ICollection<Post> Posts { get; } = new List<Post>();
}
