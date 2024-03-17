using System.ComponentModel.DataAnnotations.Schema;

namespace BirthdayParty.Domain.Models
{
    public class RoomOnDuty
    {
        public string? Id { get; set; }
        public string? PartyPackageId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; } = false;

        [ForeignKey(nameof(PartyPackageId))]
        public PartyPackage? PartyPackage { get; set; }
    }
}