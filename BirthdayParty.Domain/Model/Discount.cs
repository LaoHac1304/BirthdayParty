using System;
using System.Collections.Generic;

namespace BirthdayParty.Infrastructure.Model;

public partial class Discount
{
    public Guid Id { get; set; }

    public decimal? DiscountPercent { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<PartyPackage> PartyPackages { get; } = new List<PartyPackage>();
}
