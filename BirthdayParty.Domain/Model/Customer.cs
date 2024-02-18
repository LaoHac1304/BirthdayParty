using System;
using System.Collections.Generic;

namespace BirthdayParty.Infrastructure.Model;

public partial class Customer
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public DateTime? DayOfBirth { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual Account? User { get; set; }
}
