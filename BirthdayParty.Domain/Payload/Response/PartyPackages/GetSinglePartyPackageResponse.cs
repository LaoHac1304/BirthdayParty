using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Payload.Response.HostParties;

namespace BirthdayParty.Domain.Payload.Response.PartyPackages;

public class GetSinglePartyPackageResponse
{
     public string Id { get; set; }
    
        public string? Name { get; set; }
    
        public string? Description { get; set; }
    
        public string? Location { get; set; }
    
        public string? ImageUrl { get; set; }
    
        public DateTime? AvailableDates { get; set; }
    
        public string? HostPartyId { get; set; }
        public GetHostPartyResponse? HostParty { get; set; }

        public string? Status { get; set; }
    
        public int? Price { get; set; }
    
        public long? DiscountPercent { get; set; }
        
        public string? DiscountStatus { get; set; }
    
        public bool? AvailableForPreorder { get; set; }
    
        public DateTime? CreatedAt { get; set; }
    
        public DateTime? UpdatedAt { get; set; }
    
        public bool? IsDeleted { get; set; }
}