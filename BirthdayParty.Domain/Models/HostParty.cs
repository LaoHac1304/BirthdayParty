using System;
using System.Collections.Generic;

namespace BirthdayParty.Domain.Models;

public partial class HostParty
{
    public string Id { get; set; }

    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }

    public string? Rating { get; set; }

    public string? UserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<PartyPackage> PartyPackages { get; } = new List<PartyPackage>();

    public virtual Account? User { get; set; }
}
