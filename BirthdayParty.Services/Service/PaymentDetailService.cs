using AutoMapper;
using BirthdayParty.Application.Repository.Common;
using BirthdayParty.Application.Service;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.OrderDetails;
using BirthdayParty.Domain.Payload.Response.OrderDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BirthdayParty.Services.Service
{
    public class PaymentDetailService : BaseService<PaymentDetailService>, IPaymentDetailsService
    {
        public PaymentDetailService(IUnitOfWork unitOfWork, ILogger<PaymentDetailService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
        }

        public async Task<IPaginate<GetPaymentDetailResponse>> GetPaymentDetails(int page, int size)
        {
            IPaginate<GetPaymentDetailResponse> response
                = await _unitOfWork.GetRepository<PaymentDetail>()
                .GetPagingListAsync(
                    selector: x => new GetPaymentDetailResponse(x.Id, x.Provider, x.Amount, x.OrderDetailId, x.Status, x.CreatedAt, x.UpdatedAt, x.IsDeleted),
                    page: page,
                    size: size,
                    orderBy: x => x.OrderBy(x => x.CreatedAt));
            
            return response;
        }

        public async Task<GetPaymentDetailResponse> GetPaymentDetailById(string id)
        {
            if (id == string.Empty) throw new BadHttpRequestException("Payment Detail Id is null or not exist");

            GetPaymentDetailResponse response = await _unitOfWork.GetRepository<PaymentDetail>().SingleOrDefaultAsync(
                selector: x => new GetPaymentDetailResponse(x.Id, x.Provider, x.Amount, x.OrderDetailId, x.Status, x.CreatedAt, x.UpdatedAt, x.IsDeleted, x.OrderDetail),
                predicate: x => x.Id.Equals(id));
            
            return response;
        }

        public async Task<bool> UpdatedPaymentDetailById(string id )
        {
            if (id == string.Empty) throw new BadHttpRequestException("Payment Id is null or not exist");

            PaymentDetail order = await _unitOfWork.GetRepository<PaymentDetail>()
                .SingleOrDefaultAsync(
                predicate: x => x.Id.Equals(id));

            if (order == null) throw new BadHttpRequestException("Payment was not found");

            _unitOfWork.GetRepository<PaymentDetail>().UpdateAsync(order);
            order.IsDeleted = true;
            order.UpdatedAt = DateTime.UtcNow;

            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            return isSuccessful;
        }

        public async Task<GetPaymentDetailResponse> CreatePaymentDetail(CreatePaymentDetailsRequest createPaymentDetailRequest)
        {
            // Check customer
            var orderDetail = await _unitOfWork.GetRepository<OrderDetail>().SingleOrDefaultAsync(predicate: x => x.Id.Equals(createPaymentDetailRequest.OrderDetailId));

            if (orderDetail == null) throw new BadHttpRequestException("Order Detail was not found");

            var entity = _mapper.Map<PaymentDetail>(createPaymentDetailRequest);

            //Hotfix id
            entity.Id = Guid.NewGuid().ToString();

             await _unitOfWork.GetRepository<PaymentDetail>().InsertAsync(entity);
            await _unitOfWork.CommitAsync();

            var data = _mapper.Map<GetPaymentDetailResponse>(
                await _unitOfWork.GetRepository<PaymentDetail>()
                .SingleOrDefaultAsync(predicate: x => x.Id.Equals(entity.Id)));

            return data;
        }
    }
}