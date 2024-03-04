using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.Discounts;
using BirthdayParty.Domain.Payload.Request.OrderDetails;
using BirthdayParty.Domain.Payload.Response.Discounts;
using BirthdayParty.Domain.Payload.Response.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Application.Service.Common
{
    public interface IDiscountService
    {
        Task<IPaginate<GetDiscountResponse>> GetDiscounts(int page, int size);

        Task<GetDiscountResponse> GetDiscountById(string id);

        Task<bool> UpdateDiscountById(string id);
        Task<GetDiscountResponse> CreateDiscount(CreateDiscountRequest createDiscountRequest);
    }
}
