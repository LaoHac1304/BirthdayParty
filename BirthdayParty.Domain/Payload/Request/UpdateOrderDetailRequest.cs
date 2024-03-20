using System.ComponentModel.DataAnnotations;
using System.Configuration;
using BirthdayParty.Domain.Constants;

namespace BirthdayParty.Domain.Payload.Request;

public class UpdateOrderDetailRequest

{
    [Required(ErrorMessage = "Status is required")]
    [RegularExpression(
            "^(approved|rejected|pending)$", ErrorMessage = "Status must be approved, rejected or pending"
        )
    ]
    public string Status { get; set; }
}