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
        public OrderDetailDate(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public override bool IsValid(object value)
        {
            DateTime time = (DateTime)value;
            return time.Date >= DateTime.UtcNow.Date;
        }
    }
}
