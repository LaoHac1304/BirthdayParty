using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BirthdayParty.Domain.Payload.Request.Discounts
{
    public class CreateDiscountRequest
    {
        public long? DiscountPercent { get; set; }

        public string? Status { get; set; }
    }
}

