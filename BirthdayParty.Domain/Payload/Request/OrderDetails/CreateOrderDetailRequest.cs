using BirthdayParty.Domain.Validation.OrderDetailValidation;
using System.ComponentModel.DataAnnotations;

namespace BirthdayParty.Domain.Payload.Request.OrderDetails
{
    public class CreateOrderDetailRequest : IValidatableObject
    {
        [Required]
        public string? PartyPackageId { get; set; }

        [Required]
        public string? CustomerId { get; set; }

        public string? ChildrenName { get; set; }
        public DateTime? ChildrenBirthday { get; set; }
        // [Range(0,10,ErrorMessage = "Number of children must be between 0 and 10")]
        public int? NumberOfChildren { get; set; }
        
        public string? Gender { get; set; }
        [Range(0, 1000, ErrorMessage = "Total price must be between 0 and 1000")]
        public long? TotalPrice { get; set; }
        public DateTime? StartTime { get; set; }

        [OrderDetailDate(nameof(StartTime), "End date must be after start date.")]
        public DateTime? EndTime { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(StartTime < DateTime.Now)
                yield return new ValidationResult("Start date must not be in the past .", new[] { nameof(StartTime) });

            if (StartTime > EndTime)
            {
                yield return new ValidationResult("End date must be after start date.", new[] { nameof(EndTime) });
            }
        }
    }
}