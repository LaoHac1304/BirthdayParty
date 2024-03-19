using System;
using System.Collections.Generic;

namespace BirthdayParty.Domain.Models;

public partial class Menu
{
    public string Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? PartyPackageId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual PartyPackage? PartyPackage { get; set; }
}
