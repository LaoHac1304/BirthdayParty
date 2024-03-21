using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BirthdayParty.Domain.Payload.Request.Discounts
{
    public class CreateDiscountRequest
    {
        [Range(0, 100, ErrorMessage = "DiscountPercent must be between 0 and 100")]
        public long? DiscountPercent { get; set; }

        
        public string? Status { get; set; }
    }
}

