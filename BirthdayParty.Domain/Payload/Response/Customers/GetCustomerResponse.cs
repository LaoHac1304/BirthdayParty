using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Domain.Payload.Response.Customers
{
    public class GetCustomerResponse
    {
        public GetCustomerResponse(string? id, string? fullName, DateTime? dayOfBirth, DateTime? createdAt, DateTime? updatedAt, bool? isDeleted, string? phoneNumber, string? email, string? imageUrl)
        {
            Id = id;
            FullName = fullName;
            DayOfBirth = dayOfBirth;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsDeleted = isDeleted;
            PhoneNumber = phoneNumber;
            Email = email;
            ImageUrl = imageUrl;
            
        }

        public string Id { get; set; }
        public string? FullName { get; set; }
        public string? ImageUrl { get; set; }


        public DateTime? DayOfBirth { get; set; }
        public string? PhoneNumber { get; set; }   

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public string? Email {  get; set; }

        public bool? IsDeleted { get; set; }
    }
}
