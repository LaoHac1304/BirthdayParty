using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Domain.Payload.Request.Accounts
{
    public class UpdateAccountRequest
    {
        public string? Role {  get; set; }
        public bool? IsDeleted { get; set; }
    }
}
