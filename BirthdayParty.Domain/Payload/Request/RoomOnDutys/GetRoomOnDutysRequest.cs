﻿namespace BirthdayParty.Domain.Payload.Request.RoomOnDutys;

public class GetMenuRequest
{
    public string? Status { get; set; } = "both";
    public string? SearchString { get; set; } = "";
    public string? PartyPackageId { get; set; } = "";
    public int Page { get; set; }
    public int Size { get; set; }
}