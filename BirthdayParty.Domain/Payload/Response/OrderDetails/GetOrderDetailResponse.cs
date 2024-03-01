namespace BirthdayParty.Domain.Payload.Response.OrderDetails
{
    public class GetOrderDetailResponse
    {
        public GetOrderDetailResponse(string id, string? customerId, long? totalPrice, DateTime? date, DateTime? createdAt, DateTime? updatedAt, bool? isDeleted)
        {
            Id = id;
            CustomerId = customerId;
            TotalPrice = totalPrice;
            Date = date;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsDeleted = isDeleted;
        }

        public string Id { get; set; }
        public string? CustomerId { get; set; }

        public long? TotalPrice { get; set; }

        public DateTime? Date { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}