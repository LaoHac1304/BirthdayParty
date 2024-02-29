using System;
using System.Collections.Generic;

namespace BirthdayParty.Domain.Models;

public partial class Message
{
    public string Id { get; set; }

    public string? Content { get; set; }

    public string? SenderId { get; set; }

    public string? ReceiverId { get; set; }

    public string? Status { get; set; }

    public DateTime? SentAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Account? Receiver { get; set; }

    public virtual Account? Sender { get; set; }
}
