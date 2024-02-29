using System;
using System.Collections.Generic;

namespace BirthdayParty.Domain.Models;

public partial class Discount
{
    public string Id { get; set; }

    public long? DiscountPercent { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<PartyPackage> PartyPackages { get; } = new List<PartyPackage>();
}
