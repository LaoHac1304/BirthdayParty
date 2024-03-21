using System.ComponentModel.DataAnnotations;

namespace BirthdayParty.Domain.Payload.Request.PartyPackages;

public class GetPartyPackagesRequest
{
    public string? IsDeleted { get; set; } = "both";
    public string? SearchString { get; set; } = "";
    public string? HostPartyId { get; set; } = "";
    public string? Location { get; set; } = "";
    public string? Status { get; set; } = "both";
    [Range(0, int.MaxValue, ErrorMessage = "Page must be a positive number")]
    public int Page { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Size must be a positive number")]
    public int Size { get; set; }
}