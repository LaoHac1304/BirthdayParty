using System.ComponentModel.DataAnnotations;

namespace BirthdayParty.Domain.Payload.Request.Posts;

public class UpdatePostRequest : IValidatableObject 
{
   public string? Content { get; set; }
   public string? ImageUrl { get; set; }
   public DateTime? Date { get; set; }
   
   public string? PartyPackageId { get; set; }


   public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
   {
      if (Date < DateTime.Now)
         yield return new ValidationResult("Date cannot be in the past", new[] { nameof(Date) }); 
   }
}