using BirthdayParty.Domain.Validation.OrderDetailValidation;
using System.ComponentModel.DataAnnotations;

namespace BirthdayParty.Domain.Payload.Request.OrderDetails
{
    public class CreatePaymentDetailsRequest
    {

        public string? Provider { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public int? Amount { get; set; }

        public string? OrderDetailId { get; set; }

        public string? Status { get; set; }

        public bool? IsDeleted { get; set; }

    }
}