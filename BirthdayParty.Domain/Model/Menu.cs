using System;
using System.Collections.Generic;

namespace BirthdayParty.Infrastructure.Model;

public partial class Menu
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public Guid? PartyPackageId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual PartyPackage? PartyPackage { get; set; }
}
