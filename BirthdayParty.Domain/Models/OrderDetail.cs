using BirthdayParty.Domain.Validation.OrderDetailValidation;

namespace BirthdayParty.Domain.Models;

public partial class OrderDetail
{
    public string? Id { get; set; }
    public string? CustomerId { get; set; }

    public long? TotalPrice { get; set; }

    public DateTime? Date { get; set; } = DateTime.UtcNow;

    public DateTime? StartDate { get; set; }
    [OrderDetailDate(nameof(StartDate),"End date must be after start date.")]
    public DateTime? EndDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

    public virtual ICollection<PaymentDetail> PaymentDetails { get; } = new List<PaymentDetail>();
}