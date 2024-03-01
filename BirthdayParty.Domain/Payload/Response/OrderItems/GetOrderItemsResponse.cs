namespace BirthdayParty.Domain.Payload.Response.OrderItems
{
    public class GetOrderItemsResponse
    {
        public GetOrderItemsResponse(string id, long? price, DateTime? date, string? partyPackageId, string? orderDetailId, bool? isPreorder, string? status, DateTime? createdAt, DateTime? updatedAt, bool? isDeleted)
        {
            Id = id;
            Price = price;
            Date = date;
            PartyPackageId = partyPackageId;
            OrderDetailId = orderDetailId;
            IsPreorder = isPreorder;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsDeleted = isDeleted;
        }

        public string Id { get; set; }

        public long? Price { get; set; }

        public DateTime? Date { get; set; }

        public string? PartyPackageId { get; set; }

        public string? OrderDetailId { get; set; }

        public bool? IsPreorder { get; set; }

        public string? Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}