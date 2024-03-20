namespace BirthdayParty.Domain.Payload.Request.RoomOnDutys;

public class GetRoomOnDutysRequest
{
    public string? Status { get; set; } = "both";
    public string? SearchString { get; set; } = "";
    public string? HostPartyId { get; set; } = "";
    public int Page { get; set; }
    public int Size { get; set; }
}