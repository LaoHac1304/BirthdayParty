using System.ComponentModel.DataAnnotations.Schema;

namespace BirthdayParty.Domain.Models
{
    public class RoomOnDuty
    {
        public string? Id { get; set; }
        public string? PartyPackageId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Status { get; set; } // processing || complete
        public virtual PartyPackage? PartyPackage { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}