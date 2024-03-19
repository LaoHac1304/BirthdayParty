using AutoMapper;
using BirthdayParty.Application.Repository.Common;
using BirthdayParty.Application.Service;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.OrderDetails;
using BirthdayParty.Domain.Payload.Response.OrderDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BirthdayParty.Services.Service
{
    public class OrderDetailService : BaseService<IOrderDetailsService>, IOrderDetailsService
    {
        public OrderDetailService(IUnitOfWork unitOfWork, ILogger<IOrderDetailsService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
        }

        public async Task<IPaginate<GetOrderDetailResponse>> GetOrderDetails(int page, int size)
        {
            IPaginate<GetOrderDetailResponse> response
                = await _unitOfWork.GetRepository<OrderDetail>()
                .GetPagingListAsync(

                    selector: x => new GetOrderDetailResponse(
                        x.Id,
                        x.PartyPackageId,
                        x.CustomerId,
                        x.ChildrenName,
                        x.ChildrenBirthday,
                        x.NumberOfChildren,
                        x.TotalPrice,
                        x.StartTime,
                        x.EndTime,
                        x.Date,
                        x.CreatedAt,
                        x.UpdatedAt,
                        x.IsDeleted,
                        x.PartyPackage,
                        x.Customer,
                        x.Gender,
                        x.Status),
                    page: page,
                    size: size,
                    orderBy: x => x.OrderBy(x => x.CreatedAt));
            return response;
        }

        public async Task<GetOrderDetailResponse> GetOrderDetailById(string id)
        {
            if (id == string.Empty) throw new BadHttpRequestException("Order Detail Id is null or not exist");

            GetOrderDetailResponse response = await _unitOfWork.GetRepository<OrderDetail>().SingleOrDefaultAsync(
                selector: x => new GetOrderDetailResponse(
                        x.Id,
                        x.PartyPackageId,
                        x.CustomerId,
                        x.ChildrenName,
                        x.ChildrenBirthday,
                        x.NumberOfChildren,
                        x.TotalPrice,
                        x.StartTime,
                        x.EndTime,
                        x.Date,
                        x.CreatedAt,
                        x.UpdatedAt,
                        x.IsDeleted,
                        x.PartyPackage,
                        x.Customer,
                        x.Gender, 
                        x.Status),
                predicate: x => x.Id.Equals(id));

            return response;
        }

        public async Task<bool> UpdatedOrderDetailById(string id)
        {
            if (id == string.Empty) throw new BadHttpRequestException("Order Id is null or not exist");

            OrderDetail order = await _unitOfWork.GetRepository<OrderDetail>()
                .SingleOrDefaultAsync(
                predicate: x => x.Id.Equals(id));

            if (order == null) throw new BadHttpRequestException("Order was not found");

            _unitOfWork.GetRepository<OrderDetail>().UpdateAsync(order);
            order.IsDeleted = true;
            order.UpdatedAt = DateTime.UtcNow;

            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;

            return isSuccessful;
        }

        public async Task<GetOrderDetailResponse> CreateOrderDetail(CreateOrderDetailRequest createOrderDetailRequest)
        {
            // Check customer
            var customer = await _unitOfWork.GetRepository<Customer>()
                .SingleOrDefaultAsync(predicate: x => x.Id.Equals(createOrderDetailRequest.CustomerId));

            if (customer == null) throw new BadHttpRequestException("Customer was not found");

            // Check party package
            var partyPackage = await _unitOfWork.GetRepository<PartyPackage>()
                .SingleOrDefaultAsync(predicate: x => x.Id.Equals(createOrderDetailRequest.PartyPackageId));

            if (partyPackage == null) throw new BadHttpRequestException("Party Package was not found");

            var entity = _mapper.Map<OrderDetail>(createOrderDetailRequest);

            //Hotfix id
            entity.Id = Guid.NewGuid().ToString();

            // Calculate price
            entity.TotalPrice = (long)(partyPackage.PackagePrice 
                * Math.Ceiling((Decimal)(createOrderDetailRequest.EndTime!.Value.Hour - createOrderDetailRequest.StartTime!.Value.Hour)))!
                + (long) (partyPackage.SeatPrice * createOrderDetailRequest.NumberOfChildren)!;

            await _unitOfWork.GetRepository<OrderDetail>().InsertAsync(entity);
            await _unitOfWork.CommitAsync();

            var data = _mapper.Map<GetOrderDetailResponse>(
                await _unitOfWork.GetRepository<OrderDetail>()
                .SingleOrDefaultAsync(predicate: x => x.Id.Equals(entity.Id)));

            return data;
        }

        public async Task<IPaginate<GetOrderDetailResponse>> GetOrderDetailsByCustomerId(string id, int page, int size)
        {
            IPaginate<GetOrderDetailResponse> response
                = await _unitOfWork.GetRepository<OrderDetail>()
                .GetPagingListAsync(

                    selector: x => new GetOrderDetailResponse(
                        x.Id,
                        x.PartyPackageId,
                        x.CustomerId,
                        x.ChildrenName,
                        x.ChildrenBirthday,
                        x.NumberOfChildren,
                        x.TotalPrice,
                        x.StartTime,
                        x.EndTime,
                        x.Date,
                        x.CreatedAt,
                        x.UpdatedAt,
                        x.IsDeleted,
                        x.PartyPackage,
                        x.Customer,
                        x.Gender,
                        x.Status),
                    page: page,
                    size: size,
                    predicate: x => x.CustomerId.Equals(id),
                    orderBy: x => x.OrderBy(x => x.CreatedAt)) ;
            return response;
        }
    }
}