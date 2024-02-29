using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Domain.Payload.Response.Accounts
{
    public class CreateCustomerResponse : CreateAccountResponse
    {
        public string Id { get; set; }
        public DateTime DayOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
