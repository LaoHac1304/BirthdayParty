using BirthdayParty.Domain.Models;

using BirthdayParty.Domain.Payload.Response.HostParties;


namespace BirthdayParty.Domain.Payload.Response.PartyPackages;

public class GetSinglePartyPackageResponse
{

    public GetSinglePartyPackageResponse(string id, string? hostPartyId, string? discountId, string? name, string? description, string? location, int roomSeats, string? roomUrl, string? imageUrl, int? packagePrice, int? seatPrice, string? startTime, string? endTime, string? status, DateTime? createdAt, DateTime? updatedAt, bool? isDeleted, Discount? discount, HostParty? hostParty)
    {
        Id = id;
        HostPartyId = hostPartyId;
        DiscountId = discountId;
        Name = name;
        Description = description;
        Location = location;
        RoomSeats = roomSeats;
        RoomUrl = roomUrl;
        ImageUrl = imageUrl;
        PackagePrice = packagePrice;
        SeatPrice = seatPrice;
        StartTime = startTime;
        EndTime = endTime;
        Status = status;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        IsDeleted = isDeleted;
        Discount = discount;
        HostParty = hostParty;
    }

    public string Id { get; set; }
    public string? HostPartyId { get; set; }
    public string? DiscountId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public int RoomSeats { get; set; }
    public string? RoomUrl { get; set; }

    public string? ImageUrl { get; set; }

    //public DateTime? AvailableDates { get; set; }
    public int? PackagePrice { get; set; }
    public int? SeatPrice { get; set; }
    public string? StartTime { get; set; }

    public string? EndTime { get; set; }

    public string? Status { get; set; }

    //public bool? AvailableForPreorder { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Discount? Discount { get; set; }

    public virtual HostParty? HostParty { get; set; }

}