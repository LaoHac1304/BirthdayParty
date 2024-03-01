using BirthdayParty.Domain.Validation.OrderDetailValidation;
using System.ComponentModel.DataAnnotations;

namespace BirthdayParty.Domain.Payload.Request.OrderDetails
{
    public class CreateOrderDetailRequest
    {
        [Required]
        public string? CustomerId { get; set; }
        [Required]
        public long? TotalPrice { get; set; }
        [Required]
        [OrderDetailDate("Date must be after today.")]
        public DateTime? Date { get; set; }
    }
}