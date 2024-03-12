namespace BirthdayParty.Domain.Payload.Request.PartyPackages;

public class CreatePartyPackageRequest
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Location { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? AvailableDates { get; set; }

    public string? HostPartyId { get; set; }

    public int? Price { get; set; } = 0;

    public string? DiscountId { get; set; }

    public bool? AvailableForPreorder { get; set; } = false;
    public string? Status { get; set; } = "Inactive";
}