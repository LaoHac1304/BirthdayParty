using System;
using System.Collections.Generic;

namespace BirthdayParty.Domain.Models;

public partial class OrderItem
{
    public string Id { get; set; } = null!;

    public long? Price { get; set; }

    public DateTime? Date { get; set; }

    public string? PartyPackageId { get; set; }

    public string? OrderDetailId { get; set; }

    public bool? IsPreorder { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual OrderDetail? OrderDetail { get; set; }

    public virtual PartyPackage? PartyPackage { get; set; }
}
