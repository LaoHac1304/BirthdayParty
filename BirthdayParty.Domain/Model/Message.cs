using System;
using System.Collections.Generic;

namespace BirthdayParty.Infrastructure.Model;

public partial class Message
{
    public Guid Id { get; set; }

    public string? Content { get; set; }

    public Guid? SenderId { get; set; }

    public Guid? ReceiverId { get; set; }

    public string? Status { get; set; }

    public DateTime? SentAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Account? Receiver { get; set; }

    public virtual Account? Sender { get; set; }
}
