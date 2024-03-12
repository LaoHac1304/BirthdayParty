using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BirthdayParty.Domain.Payload.Request.Menus
{
    public class CreateMenuRequest
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public long? Price { get; set; }

        public string? PartyPackageId { get; set; }
    }
}

