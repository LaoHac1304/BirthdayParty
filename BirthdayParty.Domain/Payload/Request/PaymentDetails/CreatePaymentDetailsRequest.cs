using BirthdayParty.Domain.Validation.OrderDetailValidation;
using System.ComponentModel.DataAnnotations;

namespace BirthdayParty.Domain.Payload.Request.OrderDetails
{
    public class CreatePaymentDetailsRequest
    {

        public string? Provider { get; set; }

        public int? Amount { get; set; }

        public string? OrderDetailId { get; set; }

        public string? Status { get; set; }

        public bool? IsDeleted { get; set; }

    }
}