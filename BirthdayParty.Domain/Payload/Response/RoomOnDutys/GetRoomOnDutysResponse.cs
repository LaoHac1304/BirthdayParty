namespace BirthdayParty.Domain.Payload.Response.RoomOnDutys;

public class GetRoomOnDutysResponse
{
    public GetRoomOnDutysResponse(string? id, string? partyPackageId, DateTime startDate, DateTime endDate, string? status, DateTime? createdAt, DateTime? updatedAt)
    {
        Id = id;
        PartyPackageId = partyPackageId;
        StartDate = startDate;
        EndDate = endDate;
        Status = status;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public string? Id { get; set; }
    public string? PartyPackageId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Status { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}