using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Domain.Payload.Request.Accounts
{
    public class CreateCustomerRequest : CreateAccountRequest
    {
        public string UserId { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DayOfBirth { get; set; }
    }
}
