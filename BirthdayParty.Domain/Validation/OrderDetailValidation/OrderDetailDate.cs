using BirthdayParty.Domain.Payload.Request.OrderDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Domain.Validation.OrderDetailValidation
{
    public class OrderDetailDate : ValidationAttribute
    {
        private readonly string _startDate;
        public OrderDetailDate(string startDate, string errorMessage)
        {
            ErrorMessage = errorMessage;
            _startDate = startDate;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var startDateProperty = validationContext.ObjectType.GetProperty(_startDate);
            if (startDateProperty == null) { return new ValidationResult($"Unknown property: {_startDate}"); }

            var startDate = startDateProperty.GetValue(validationContext.ObjectInstance, null);
            var endDateValue = (DateTime)value;

            if (endDateValue < (DateTime)startDate!)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success!;
        }
    }
}
