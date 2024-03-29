﻿using System;
using System.Collections.Generic;

namespace BirthdayParty.Domain.Models;

public partial class Account
{
    public string? Id { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    //public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

    //public virtual ICollection<HostParty> HostParties { get; } = new List<HostParty>();

    //public virtual ICollection<Message> MessageReceivers { get; } = new List<Message>();

    //public virtual ICollection<Message> MessageSenders { get; } = new List<Message>();
}
