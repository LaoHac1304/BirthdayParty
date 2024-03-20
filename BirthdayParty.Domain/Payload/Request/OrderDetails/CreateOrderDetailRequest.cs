using BirthdayParty.Domain.Validation.OrderDetailValidation;
using System.ComponentModel.DataAnnotations;

namespace BirthdayParty.Domain.Payload.Request.OrderDetails
{
    public class CreateOrderDetailRequest
    {
        [Required]
        public string? PartyPackageId { get; set; }

        [Required]
        public string? CustomerId { get; set; }

        public string? ChildrenName { get; set; }
        public DateTime? ChildrenBirthday { get; set; }
        public int? NumberOfChildren { get; set; }
        public string? Gender { get; set; }
        public long? TotalPrice { get; set; }
        public DateTime? StartTime { get; set; }

        [OrderDetailDate(nameof(StartTime), "End date must be after start date.")]
        public DateTime? EndTime { get; set; }
    }
}