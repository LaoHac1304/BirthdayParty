using BirthdayParty.Domain.Models;

namespace BirthdayParty.Domain.Payload.Response.OrderDetails
{
    public class GetOrderDetailResponse
    {
        public GetOrderDetailResponse(string id, string? customerId, Customer customer, long? totalPrice, DateTime? date, DateTime? createdAt, DateTime? updatedAt, bool? isDeleted)
        {
            Id = id;
            CustomerId = customerId;
            Customer = customer;
            TotalPrice = totalPrice;
            Date = date;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsDeleted = isDeleted;
        }

        public string Id { get; set; }
        public string? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public long? TotalPrice { get; set; }

        public DateTime? Date { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}