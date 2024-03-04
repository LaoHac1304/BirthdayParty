using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Domain.Payload.Response.Menus
{
    public class GetMenuResponse
    {
        public GetMenuResponse(string id, string? name, string? description, long? price, DateTime? createdAt, DateTime? updatedAt, bool? isDeleted)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsDeleted = isDeleted;
        }

        public string Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public long? Price { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}

