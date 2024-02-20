using System;
using System.Collections.Generic;

namespace BirthdayParty.Domain.Models;

public partial class Post
{
    public string Id { get; set; } = null!;

    public string? Content { get; set; }

    public DateTime? Date { get; set; }

    public string? ImageUrl { get; set; }

    public string? PartyPackageId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual PartyPackage? PartyPackage { get; set; }
}
