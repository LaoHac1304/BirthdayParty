using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Domain.Payload.Request.Customers
{
    public class UpdateCustomerRequest
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DayOfBirth { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
