namespace BirthdayParty.Domain.Payload.Request.PartyPackages;

public class GetPartyPackagesRequest
{
    public string? IsDeleted { get; set; } = "both";
    public string? SearchString { get; set; } = "";
    public string? HostPartyId { get; set; } = "";
    public string? Location { get; set; } = "";
    public string? Status { get; set; } = "both";
    public int Page { get; set; }
    public int Size { get; set; }
}