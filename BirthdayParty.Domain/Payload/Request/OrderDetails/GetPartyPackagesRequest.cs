namespace BirthdayParty.Domain.Payload.Request.OrderDetails;

public class GetOrderDetailsRequest
{
    public string? IsDeleted { get; set; } = "both";
    public string? SearchString { get; set; } = "";
    public string? HostPartyId { get; set; } = "";
    public int Page { get; set; }
    public int Size { get; set; }
}