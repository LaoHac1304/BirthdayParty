using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Domain.Payload.Response.Accounts
{
    public class GetAccountResponse
    {
        private DateTime? createdAt;
        private DateTime? updatedAt;
        private bool? isDeleted;

        public GetAccountResponse(string id, string? email, string? role, DateTime? createdAt, DateTime? updatedAt, bool? isDeleted)
        {
            Id = id;
            Email = email;
            Role = role;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
            this.isDeleted = isDeleted;
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
