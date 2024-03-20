
﻿using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Validation.OrderDetailValidation;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthdayParty.Domain.Payload.Response.OrderDetails
{
    public class GetOrderDetailResponse
    {
        public GetOrderDetailResponse(string? id, string? partyPackageId, string? customerId
            , string? childrenName, DateTime? childrenBirthday, int? numberOfChildren
            , long? totalPrice, DateTime? startTime, DateTime? endTime, DateTime? date, DateTime? createdAt, DateTime? updatedAt
            , bool? isDeleted, PartyPackage? partyPackage, Customer? customer, string? gender, string? status)
        {
            Id = id;
            PartyPackageId = partyPackageId;
            CustomerId = customerId;
            ChildrenName = childrenName;
            ChildrenBirthday = childrenBirthday;
            NumberOfChildren = numberOfChildren;
            TotalPrice = totalPrice;
            StartTime = startTime;
            EndTime = endTime;
            Date = date;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsDeleted = isDeleted;
            PartyPackage = partyPackage;
            Customer = customer;
            Gender = gender;
            Status = status;
        }

        public string? Id { get; set; }
        public string? PartyPackageId { get; set; }
        public string? CustomerId { get; set; }
        public string? ChildrenName { get; set; }
        public DateTime? ChildrenBirthday { get; set; }
        public int? NumberOfChildren { get; set; }
        public long? TotalPrice { get; set; }
        public string? Gender { get; set; }

        public DateTime? StartTime { get; set; }

        [OrderDetailDate(nameof(StartTime), "End date must be after start date.")]
        public DateTime? EndTime { get; set; }
        public string? Status { get; set; } = "PENDING";

        public DateTime? Date { get; set; } = DateTime.UtcNow;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool? IsDeleted { get; set; }

        [ForeignKey(nameof(PartyPackageId))]
        public virtual PartyPackage? PartyPackage { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer? Customer { get; set; }
    }
}