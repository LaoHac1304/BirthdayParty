using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Domain.Payload.Request.HostParties
{
    public class CreateHostPartyRequest
    {
        public string? UserId { get; set; }
        public string? Description { get; set;}
        public string? Email { get; set; }
    }
}
