using System;
using System.Collections.Generic;

namespace BirthdayParty.Infrastructure.Model;

public partial class HostParty
{
    public Guid Id { get; set; }

    public string? Description { get; set; }

    public string? Rating { get; set; }

    public Guid? UserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<PartyPackage> PartyPackages { get; } = new List<PartyPackage>();

    public virtual Account? User { get; set; }
}
