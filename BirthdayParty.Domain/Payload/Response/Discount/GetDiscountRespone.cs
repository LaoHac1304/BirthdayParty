using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Domain.Payload.Response.Discounts
{
    public class GetDiscountResponse
    {
        public GetDiscountResponse(string id, long? discountPercent, string? status, DateTime? createdAt, DateTime? updatedAt, bool? isDeleted)
        {
            Id = id;
            DiscountPercent = discountPercent;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsDeleted = isDeleted;
        }

        public string Id { get; set; }

        public long? DiscountPercent { get; set; }

        public string? Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}

