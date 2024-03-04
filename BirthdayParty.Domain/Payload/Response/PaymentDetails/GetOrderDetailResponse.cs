using BirthdayParty.Domain.Models;

namespace BirthdayParty.Domain.Payload.Response.OrderDetails
{
    public class GetPaymentDetailResponse
    {
        public GetPaymentDetailResponse(string id, string? provider, int? amount, string? orderDetailId, string? status, DateTime? createdAt, DateTime? updatedAt, bool? isDeleted)
        {
            Id = id;
            Provider = provider;
            Amount = amount;
            OrderDetailId = orderDetailId;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsDeleted = isDeleted;
        }

        public GetPaymentDetailResponse(string id, string? provider, int? amount, string? orderDetailId, string? status, DateTime? createdAt, DateTime? updatedAt, bool? isDeleted, OrderDetail? orderDetail)
        {
            Id = id;
            Provider = provider;
            Amount = amount;
            OrderDetailId = orderDetailId;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsDeleted = isDeleted;
            OrderDetail = orderDetail;
        }

    public string Id { get; set; }

    public string? Provider { get; set; }

    public int? Amount { get; set; }

    public string? OrderDetailId { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual OrderDetail? OrderDetail { get; set; }
    }
}