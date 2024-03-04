using BirthdayParty.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Domain.Payload.Response.HostParties
{
    public class GetHostPartyResponse
    {
        public GetHostPartyResponse(string id, string? description, string? rating, DateTime? createdAt, DateTime? updatedAt, bool? isDeleted)
        {
            Id = id;
            Description = description;
            Rating = rating;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsDeleted = isDeleted;
        }

        public string Id { get; set; }

        public string? Description { get; set; }

        public string? Rating { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
