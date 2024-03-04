using AutoMapper;
using BirthdayParty.Application.Repository.Common;
using BirthdayParty.Application.Service.Common;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.Discounts;
using BirthdayParty.Domain.Payload.Response.Discounts;
using BirthdayParty.Domain.Payload.Response.OrderDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Services.Service
{
    public class DiscountService : BaseService<IDiscountService>, IDiscountService
    {
        public DiscountService(IUnitOfWork unitOfWork, ILogger<IDiscountService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
        }

        public async Task<GetDiscountResponse> CreateDiscount(CreateDiscountRequest createDiscountRequest)
        {
            Discount discount = _mapper.Map<Discount>(createDiscountRequest);
            discount.CreatedAt = DateTime.UtcNow;

            await _unitOfWork.GetRepository<Discount>().InsertAsync(discount);
            await _unitOfWork.CommitAsync();

            GetDiscountResponse response = _mapper.Map<GetDiscountResponse>(discount);
            return response;
        }

        public async Task<GetDiscountResponse> GetDiscountById(string id)
        {
            if (id == string.Empty) throw new BadHttpRequestException("Discount Id is null or not exist");

            GetDiscountResponse response = await _unitOfWork.GetRepository<Discount>().SingleOrDefaultAsync(
                selector: x => new GetDiscountResponse(x.Id, x.DiscountPercent, x.Status, x.CreatedAt, x.UpdatedAt, x.IsDeleted),
                predicate: x => x.Id.Equals(id));

            return response;
        }

        public async Task<IPaginate<GetDiscountResponse>> GetDiscounts(int page, int size)
        {
            IPaginate<GetDiscountResponse> response
                = await _unitOfWork.GetRepository<Discount>()
                .GetPagingListAsync(
                    selector: x => new GetDiscountResponse(x.Id, x.DiscountPercent, x.Status, x.CreatedAt, x.UpdatedAt, x.IsDeleted),
                    page: page,
                    size: size,
                    orderBy: x => x.OrderBy(x => x.CreatedAt));

            return response;
        }

        public async Task<bool> UpdateDiscountById(string id)
        {
            if (id == string.Empty) throw new BadHttpRequestException("Discount Id is null or not exist");

            Discount discount = await _unitOfWork.GetRepository<Discount>()
                .SingleOrDefaultAsync(
                predicate: x => x.Id.Equals(id));

            if (discount == null) throw new BadHttpRequestException("Discount was not found");

            _unitOfWork.GetRepository<Discount>().UpdateAsync(discount);
            discount.IsDeleted = true;
            discount.UpdatedAt = DateTime.UtcNow;

            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            return isSuccessful;
        }
    }
}
