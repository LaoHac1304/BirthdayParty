using BirthdayParty.Domain.Validation.RoomOnDutyValidation;

namespace BirthdayParty.Domain.Payload.Request.RoomOnDutys;

public class CreateRoomOnDutyRequest
{
    public string PartyPackageId { get; set; }
    public DateTime StartDate { get; set; }
    [RoomOnDutyDate(startDate: nameof(StartDate), errorMessage: "End Date must be after Start Date")]
    public DateTime EndDate { get; set; }
    public string? Status { get; set; }
}