using System;
using System.Collections.Generic;

namespace BirthdayParty.Infrastructure.Model;

public partial class Post
{
    public Guid Id { get; set; }

    public string? Content { get; set; }

    public DateTime? Date { get; set; }

    public string? ImageUrl { get; set; }

    public Guid? PartyPackageId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual PartyPackage? PartyPackage { get; set; }
}
