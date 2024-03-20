using BirthdayParty.Domain.Models;

namespace BirthdayParty.Domain.Payload.Response.RoomOnDutys;

public class GetSingleRoomOnDutyResponse
{
    public GetSingleRoomOnDutyResponse(string? id, string? partyPackageId, DateTime startDate, DateTime endDate, string? status, PartyPackage? partyPackage, DateTime? createdAt, DateTime? updatedAt)
    {
        Id = id;
        PartyPackageId = partyPackageId;
        StartDate = startDate;
        EndDate = endDate;
        Status = status;
        PartyPackage = partyPackage;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public string? Id { get; set; }
    public string? PartyPackageId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Status { get; set; }
    public virtual PartyPackage? PartyPackage { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}