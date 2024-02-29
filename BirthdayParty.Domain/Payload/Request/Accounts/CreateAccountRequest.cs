using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Domain.Payload.Request.Accounts
{
    public class CreateAccountRequest
    {
        public string? FullName { get; set; }
        public string? PhoneNumber {  get; set; }
        public string? Email { get; set; }
        
    }
}
