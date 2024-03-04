namespace BirthdayParty.Domain.Payload.Request.PartyPackages;

public class GetPartyPackagesRequest
{
    public int Page { get; set; }
    public int Size { get; set; }
}