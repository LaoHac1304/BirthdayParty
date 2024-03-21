﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Domain.Payload.Request.Accounts
{
    public class CreateAccountRequest
    {
        public string? FullName { get; set; }

        [RegularExpression(@"(09|03|07|08|05)([0-9]{8})\b", ErrorMessage = "Invalid Phone Number")]
        public string? PhoneNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }
}