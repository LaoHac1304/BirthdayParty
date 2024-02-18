using System;
using System.Collections.Generic;

namespace BirthdayParty.Infrastructure.Model;

public partial class OrderItem
{
    public Guid Id { get; set; }

    public decimal? Price { get; set; }

    public DateTime? Date { get; set; }

    public Guid? PartyPackageId { get; set; }

    public Guid? OrderDetailId { get; set; }

    public bool? IsPreorder { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual OrderDetail? OrderDetail { get; set; }

    public virtual PartyPackage? PartyPackage { get; set; }
}
