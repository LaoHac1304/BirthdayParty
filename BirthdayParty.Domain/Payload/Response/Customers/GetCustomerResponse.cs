using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Domain.Payload.Response.Customers
{
    public class GetCustomerResponse
    {
        public GetCustomerResponse(string? id, string? fullName, DateTime? dayOfBirth, DateTime? createdAt, DateTime? updatedAt, bool? isDeleted, string? phoneNumber)
        {
            Id = id;
            FullName = fullName;
            DayOfBirth = dayOfBirth;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsDeleted = isDeleted;
            PhoneNumber = phoneNumber;
        }

        public string Id { get; set; }
        public string? FullName { get; set; }


        public DateTime? DayOfBirth { get; set; }
        public string? PhoneNumber { get; set; }   

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
