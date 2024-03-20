namespace BirthdayParty.Domain.Payload.Request.RoomOnDutys;

public class CreateRoomOnDutyRequest
{
    public string PartyPackageId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Status { get; set; }
}