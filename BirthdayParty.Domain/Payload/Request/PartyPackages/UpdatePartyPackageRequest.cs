using System.ComponentModel.DataAnnotations;

namespace BirthdayParty.Domain.Payload.Request.PartyPackages;

public class UpdatePartyPackageRequest : IValidatableObject
{

    public string? DiscountId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public int RoomSeats { get; set; }
    public string? RoomUrl { get; set; }

    public string? ImageUrl { get; set; }

    //public DateTime? AvailableDates { get; set; }
    public int? PackagePrice { get; set; }
    public int? SeatPrice { get; set; }
    public string? StartTime { get; set; }

    public string? EndTime { get; set; }
    public string? Status { get; set; }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (DateTime.Parse(StartTime) > DateTime.Parse(EndTime)) 
            yield return new ValidationResult("Start time must be before end time");
        
        if(DateTime.Parse(StartTime) < DateTime.Now)
            yield return new ValidationResult("Start time must be in the future");
    }
}