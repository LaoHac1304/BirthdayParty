using BirthdayParty.Domain.Validation.OrderDetailValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Domain.Payload.Request.OrderDetails
{
    public class GmailOrderDetailRequest
    {
        public string? ChildrenName { get; set; }
        public long? TotalPrice { get; set; }
        public DateTime? StartTime { get; set;}
        public DateTime? EndTime { get; set;}
        public DateTime? ChildrenBirthday { get; set; }
        public int? NumberOfChildren { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? PackageName { get; set; }
        public string? HostPartyPhoneNumber { get; set; }
    }
}
