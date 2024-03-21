using System.ComponentModel.DataAnnotations;

namespace BirthdayParty.Domain.Payload.Request.PartyPackages;

public class CreatePartyPackageRequest : IValidatableObject
{
    public string? HostPartyId { get; set; }
    public string? DiscountId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    [Range(0, int.MaxValue,ErrorMessage = "Room seats must be greater than 0")]
    public int RoomSeats { get; set; }
    public string? RoomUrl { get; set; }

    public string? ImageUrl { get; set; }

    //public DateTime? AvailableDates { get; set; }
    [Range(0, int.MaxValue,ErrorMessage = "Package price must be greater than 0")]
    public int? PackagePrice { get; set; }
    [Range(0, int.MaxValue,ErrorMessage = "Seat price must be greater than 0")]
    public int? SeatPrice { get; set; }
    public string? StartTime { get; set; }

    public string? EndTime { get; set; }
    //public string? Status { get; set; } = "Inactive";
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if(DateTime.TryParse(StartTime, out var start) == false || DateTime.TryParse(EndTime, out var end) == false)
        {
            yield return new ValidationResult("Unable to parse start and end time");
            yield break;
        }
        
        if (DateTime.Parse(StartTime) > DateTime.Parse(EndTime))
        {
            yield return new ValidationResult("Start time must be before end time");
        }

        if (DateTime.Parse(StartTime) < DateTime.Now)
        {
            yield return new ValidationResult("Start time must be in the future");
        }
    }
}