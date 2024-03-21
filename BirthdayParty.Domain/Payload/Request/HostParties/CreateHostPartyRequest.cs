using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Domain.Payload.Request.HostParties
{
    public class CreateHostPartyRequest
    {
        public string? UserId { get; set; }
        public string? Description { get; set;}
        [EmailAddress]
        public string? Email { get; set; }
        
        [RegularExpression(@"(09|03|07|08|05)([0-9]{8})\b", ErrorMessage = "Invalid Phone Number")]
        public string? PhoneNumber { get; set;}
        public string? Rating { get; set; }
    }
}
