using System;
using System.Collections.Generic;

namespace BirthdayParty.Infrastructure.Model;

public partial class OrderDetail
{
    public Guid Id { get; set; }

    public decimal? TotalPrice { get; set; }

    public DateTime? Date { get; set; }

    public Guid? CustomerId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

    public virtual ICollection<PaymentDetail> PaymentDetails { get; } = new List<PaymentDetail>();
}
