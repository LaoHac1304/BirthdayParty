using System.ComponentModel.DataAnnotations;

namespace BirthdayParty.Domain.Payload.Request.RoomOnDutys;

public class GetRoomOnDutysRequest
{
    public string? Status { get; set; } = "";
    public string? SearchString { get; set; } = "";
    //public string? HostPartyId { get; set; } = "";
    [Range(0, int.MaxValue, ErrorMessage = "Page must be greater than or equal to 0")]
    public int Page { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Size must be greater than or equal to 0")]
    public int Size { get; set; }

    public string? PartyPackageId { get; set; }
}