//using AutoMapper;
//using BirthdayParty.Application.Repository.Common;
//using BirthdayParty.Application.Service.Common;
//using BirthdayParty.Domain.Models;
//using BirthdayParty.Domain.Paginate;
//using BirthdayParty.Domain.Payload.Request.OrderItems;
//using BirthdayParty.Domain.Payload.Response.OrderItems;
//using Microsoft.AspNetCore.Http;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;

//namespace BirthdayParty.Services.Service
//{
//    public class OrderItemService : BaseService<IOrderItemsService>, IOrderItemsService
//    {
//        public OrderItemService(IUnitOfWork unitOfWork, ILogger<IOrderItemsService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
//        {
//        }

//        public async Task<GetOrderItemsResponse> CreateOrderItem(CreateOrderItemsRequest createOrderItemsRequest)
//        {
//            // Check party package
//            var package = await _unitOfWork.GetRepository<PartyPackage>()
//                .SingleOrDefaultAsync(predicate: c => c.Id.Equals(createOrderItemsRequest.PartyPackageId));

//            if (package == null) throw new BadHttpRequestException("Party package not found");

//            // Check order detail
//            var orderDetail = await _unitOfWork.GetRepository<OrderDetail>()
//                .SingleOrDefaultAsync(predicate: c => c.Id.Equals(createOrderItemsRequest.OrderDetailId));

//            var entity = _mapper.Map<OrderItem>(createOrderItemsRequest);

//            //Hotfix id
//            entity.Id = Guid.NewGuid().ToString();

//            await _unitOfWork.GetRepository<OrderItem>().InsertAsync(entity);
//            await _unitOfWork.CommitAsync();

//            var data = _mapper.Map<GetOrderItemsResponse>(
//                await _unitOfWork.GetRepository<OrderItem>()
//                .SingleOrDefaultAsync(predicate: x => x.Id.Equals(entity.Id)));

//            return data;
//        }

//        public async Task<IPaginate<GetOrderItemsResponse>> GetOrderItems(int page, int size)
//        {
//            IPaginate<GetOrderItemsResponse> response
//            = await _unitOfWork.GetRepository<OrderItem>()
//            .GetPagingListAsync(
//                include: x => x
//                .Include(x => x.OrderDetail!)
//                .ThenInclude(x => x.Customer!)
//                .ThenInclude(x => x.User!),

//                selector: x => new GetOrderItemsResponse(
//                    x.Id,
//                    x.Price,
//                    x.Date,
//                    x.PartyPackageId,
//                    x.PartyPackage!,
//                    x.OrderDetailId,
//                    x.OrderDetail!,
//                    x.IsPreorder,
//                    x.Status,
//                    x.CreatedAt,
//                    x.UpdatedAt,
//                    x.IsDeleted),
//                page: page,
//                size: size,
//                orderBy: x => x.OrderBy(x => x.CreatedAt));

//            return response;
//        }

//        public async Task<GetOrderItemsResponse> GetOrderItem(string id)
//        {
//            if (id == string.Empty) throw new BadHttpRequestException("Order Item Id is null or not exist");

//            GetOrderItemsResponse response = await _unitOfWork.GetRepository<OrderItem>().SingleOrDefaultAsync(
//                selector: x => new GetOrderItemsResponse(
//                    x.Id,
//                    x.Price,
//                    x.Date,
//                    x.PartyPackageId,
//                    x.PartyPackage!,
//                    x.OrderDetailId,
//                    x.OrderDetail!,
//                    x.IsPreorder,
//                    x.Status,
//                    x.CreatedAt,
//                    x.UpdatedAt,
//                    x.IsDeleted),
//                predicate: x => x.Id.Equals(id));

//            return response;
//        }

//        public async Task<bool> UpdateOrderItem(string id, UpdateOrderItemsRequest updateOrderItemsRequest)
//        {
//            try
//            {
//                if (id == string.Empty) throw new BadHttpRequestException("Order Id is null or not exist");

//                OrderItem orderItem = await _unitOfWork.GetRepository<OrderItem>()
//                    .SingleOrDefaultAsync(
//                    include: x => x
//                        .Include(x => x.OrderDetail!)
//                        .ThenInclude(x => x.Customer!)
//                        .ThenInclude(x => x.User!),
//                    predicate: x => x.Id.Equals(id));

//                if (orderItem == null) throw new BadHttpRequestException("Order item was not found");

//                orderItem.IsPreorder = updateOrderItemsRequest.IsPreorder;
//                orderItem.Status = updateOrderItemsRequest.Status;
//                orderItem.IsDeleted = updateOrderItemsRequest.IsDeleted;

//                orderItem.UpdatedAt = DateTime.UtcNow;

//                _unitOfWork.GetRepository<OrderItem>().UpdateAsync(orderItem);

//                bool isSuccessful = await _unitOfWork.CommitAsync() > 0;

//                return isSuccessful;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }
//    }
//}