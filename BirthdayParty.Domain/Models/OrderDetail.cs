using System;
using System.Collections.Generic;

namespace BirthdayParty.Domain.Models;

public partial class OrderDetail
{
    public string Id { get; set; }

    public long? TotalPrice { get; set; }

    public DateTime? Date { get; set; }

    public string? CustomerId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

    public virtual ICollection<PaymentDetail> PaymentDetails { get; } = new List<PaymentDetail>();
}
