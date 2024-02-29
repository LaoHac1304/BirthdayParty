using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Domain.Payload.Request.Authentications
{
    public class LoginRequest
    {
        public string AccessToken { get; set; }
        public string TokenId { get; set; }
    }
}
