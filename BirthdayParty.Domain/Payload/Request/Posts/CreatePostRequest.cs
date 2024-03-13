using Microsoft.AspNetCore.Http;

namespace BirthdayParty.Domain.Payload.Request.Posts;

public class CreatePostRequest
{
   public string? Content { get; set; } 
   public DateTime? Date { get; set; }
   public string? PartyPackageId { get; set; }
   public IFormFile? ImageUrl { get; set; }
}