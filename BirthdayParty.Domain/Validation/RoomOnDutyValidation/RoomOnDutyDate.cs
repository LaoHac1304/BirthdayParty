using System.ComponentModel.DataAnnotations;

namespace BirthdayParty.Domain.Validation.RoomOnDutyValidation;

public class RoomOnDutyDate : ValidationAttribute
{
   private readonly DateTime _startDate;

   public RoomOnDutyDate(string startDate, string errorMessage)
   {
      if (!DateTime.TryParse(startDate, out _startDate))
      {
         throw new ArgumentException("Invalid date format", nameof(startDate));
      }
      ErrorMessage = errorMessage;
   }

   protected override ValidationResult IsValid(object value, ValidationContext validationContext)
   {
      var startDateProperty = validationContext.ObjectType.GetProperty(nameof(_startDate));
      if (startDateProperty == null) { return new ValidationResult($"Unknown property: {_startDate}"); }
      
      var startDate = (DateTime)startDateProperty.GetValue(validationContext.ObjectInstance, null);
      var endDateValue = (DateTime)value;
      
      if (endDateValue < startDate)
      {
         return new ValidationResult(ErrorMessage);
      }
      
      return ValidationResult.Success!;
   }
}