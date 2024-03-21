using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BirthdayParty.Domain.Payload.Request.Menu
{
    public class CreateMenuRequest
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Range(0,long.MaxValue,ErrorMessage = "Price must be greater than 0")]
        public long? Price { get; set; }

        public string? PartyPackageId { get; set; }
    }
}

