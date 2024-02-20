using System;
using System.Collections.Generic;

namespace BirthdayParty.Domain.Models;

public partial class Customer
{
    public string Id { get; set; } = null!;

    public string? UserId { get; set; }

    public DateTime? DayOfBirth { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual Account? User { get; set; }
}
