using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Domain.Payload.Request.HostParties
{
    public class UpdateHostPartyRequest
    {
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? Rating {get; set; }
        public string? PhoneNumber { get; set;}
        public bool? IsDeleted { get; set; }
    }
}
