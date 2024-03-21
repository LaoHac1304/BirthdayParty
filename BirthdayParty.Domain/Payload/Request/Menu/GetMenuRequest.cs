using System.ComponentModel.DataAnnotations;

namespace BirthdayParty.Domain.Payload.Request.Menu;

public class GetMenuRequest
{
    public string? Status { get; set; } = "both";
    public string? SearchString { get; set; } = "";
    public string? HostPartyId { get; set; } = "";
    [Range(0, int.MaxValue, ErrorMessage = "Page must be a positive number")]
    public int Page { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Size must be a positive number")]
    public int Size { get; set; }
}