using System;
using System.Collections.Generic;

namespace BirthdayParty.Infrastructure.Model;

public partial class Account
{
    public Guid Id { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public string? PhoneNumber { get; set; }

    public string? FullName { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

    public virtual ICollection<HostParty> HostParties { get; } = new List<HostParty>();

    public virtual ICollection<Message> MessageReceivers { get; } = new List<Message>();

    public virtual ICollection<Message> MessageSenders { get; } = new List<Message>();
}
