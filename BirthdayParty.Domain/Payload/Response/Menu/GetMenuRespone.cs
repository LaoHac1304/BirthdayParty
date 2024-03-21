using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Domain.Payload.Response.Menus
{
    public class GetMenuResponse
    {
        public GetMenuResponse(string id, string? name, string? description, DateTime? createdAt, DateTime? updatedAt, bool? isDeleted, string? partyPackageId)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsDeleted = isDeleted;
            PartyPackageId = partyPackageId;    
        }

        public string Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? PartyPackageId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}

