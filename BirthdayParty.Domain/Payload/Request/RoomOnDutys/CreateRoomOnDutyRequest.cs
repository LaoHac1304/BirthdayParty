﻿using System.ComponentModel.DataAnnotations;
using BirthdayParty.Domain.Validation.RoomOnDutyValidation;

namespace BirthdayParty.Domain.Payload.Request.RoomOnDutys;

public class CreateRoomOnDutyRequest : IValidatableObject
{
    public string PartyPackageId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Status { get; set; }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
       if(StartDate > EndDate)
       {
           yield return new ValidationResult("Start date must be less than end date", new[] { nameof(StartDate) });
       }

       if (StartDate < DateTime.Now)
       {
           yield return new ValidationResult("Start date must be greater than current date", new[] { nameof(StartDate) });
           
       }
    }
}