using System.ComponentModel.DataAnnotations;

namespace BirthdayParty.Domain.Payload.Request.OrderDetails;

public class GetOrderDetailsRequest
{
    public string? IsDeleted { get; set; } = "both";
    public string? SearchString { get; set; } = "";
    public string? CustomerId { get; set; } = "";
    public string? HostPartyId { get; set; } = "";
    [Range(0,Int32.MaxValue,ErrorMessage = "Page must be greater than 0")]
    public int Page { get; set; }
    [Range(0, Int32.MaxValue, ErrorMessage = "Size must be greater than 0")]
    public int Size { get; set; }
}