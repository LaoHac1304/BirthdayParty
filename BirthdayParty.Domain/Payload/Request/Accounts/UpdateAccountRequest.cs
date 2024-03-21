using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Domain.Payload.Request.Accounts
{
    public class UpdateAccountRequest
    {
        [RegularExpression(
            "^(admin|customer|host)$",ErrorMessage = "Role must be admin, customer or host")]
        public string? Role {  get; set; }
        public bool? IsDeleted { get; set; }
    }
}
