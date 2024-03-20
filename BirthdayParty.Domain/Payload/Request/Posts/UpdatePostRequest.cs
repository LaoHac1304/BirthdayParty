namespace BirthdayParty.Domain.Payload.Request.Posts;

public class UpdatePostRequest
{
   public string? Content { get; set; }
   public string? ImageUrl { get; set; }
   public DateTime? Date { get; set; }
   
   public string? PartyPackageId { get; set; }
}