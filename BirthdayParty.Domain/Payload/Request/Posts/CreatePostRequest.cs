using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BirthdayParty.Domain.Payload.Request.Posts;

public class CreatePostRequest: IValidatableObject
{
   public string? Content { get; set; } 
   public DateTime? Date { get; set; }
   public string? PartyPackageId { get; set; }
   public IFormFile? ImageUrl { get; set; }


   public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
   {
      if (Date < DateTime.Now)
      {
         yield return new ValidationResult("Date must be in the future.", new[] { nameof(Date) });
      }
   }
}