using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Domain.Payload.Request.OrderItems
{
    public class CreateOrderItemsRequest : IValidatableObject
    
    {
        [Range(0,long.MaxValue,ErrorMessage ="Quantity must be greater than 0")]
        public long? Price { get; set; }

        public DateTime? Date { get; set; }

        public string? PartyPackageId { get; set; }

        public string? OrderDetailId { get; set; }

        public bool? IsPreorder { get; set; }

        public string? Status { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Date < DateTime.Now)
                yield return new ValidationResult("Date must not be in the past",
                    new[] { nameof(Date) });
        }
    }
}
