using System;
using System.Collections.Generic;

namespace BirthdayParty.Infrastructure.Model;

public partial class PaymentDetail
{
    public Guid Id { get; set; }

    public string? Provider { get; set; }

    public int? Amount { get; set; }

    public Guid? OrderDetailId { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual OrderDetail? OrderDetail { get; set; }
}
