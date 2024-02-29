using System;
using System.Collections.Generic;

namespace BirthdayParty.Domain.Models;

public partial class PaymentDetail
{
    public string Id { get; set; }

    public string? Provider { get; set; }

    public int? Amount { get; set; }

    public string? OrderDetailId { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual OrderDetail? OrderDetail { get; set; }
}
