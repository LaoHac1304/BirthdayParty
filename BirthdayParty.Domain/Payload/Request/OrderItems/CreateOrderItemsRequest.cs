using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Domain.Payload.Request.OrderItems
{
    public class CreateOrderItemsRequest
    {
        public long? Price { get; set; }

        public DateTime? Date { get; set; }

        public string? PartyPackageId { get; set; }

        public string? OrderDetailId { get; set; }

        public bool? IsPreorder { get; set; }

        public string? Status { get; set; }
    }
}
