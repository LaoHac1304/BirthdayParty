using BirthdayParty.Domain.Validation.OrderDetailValidation;
using System.ComponentModel.DataAnnotations.Schema;
using BirthdayParty.Domain.Constants;

namespace BirthdayParty.Domain.Models;

public partial class OrderDetail
{
    public string? Id { get; set; }
    public string? PartyPackageId { get; set; }
    public string? CustomerId { get; set; }
    public string? ChildrenName { get; set; }
    public DateTime? ChildrenBirthday { get; set; }
    public int? NumberOfChildren { get; set; }
    public long? TotalPrice { get; set; }

    public DateTime? StartTime { get; set; }

    [OrderDetailDate(nameof(StartTime), "End date must be after start date.")]
    public DateTime? EndTime { get; set; }
    public string? Gender { get; set; }

    public DateTime? Date { get; set; } = DateTime.UtcNow;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }
    public string? Status { get; set; } = OrderDetailStatus.Pending; 

    [ForeignKey(nameof(PartyPackageId))]
    public virtual PartyPackage? PartyPackage { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public virtual Customer? Customer { get; set; }

    //public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

    public virtual ICollection<PaymentDetail> PaymentDetails { get; } = new List<PaymentDetail>();
}