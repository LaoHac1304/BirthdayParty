using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request;
using BirthdayParty.Domain.Payload.Request.OrderDetails;
using BirthdayParty.Domain.Payload.Response.OrderDetails;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BirthdayParty.Application.Service
{
    public interface IOrderDetailsService
    {
        Task<IPaginate<GetOrderDetailResponse>> GetOrderDetails(GetOrderDetailsRequest request);

        Task<GetOrderDetailResponse> GetOrderDetailById(string id);

        Task<bool> SoftDeleteOrderDetail(string id);

        Task<GetOrderDetailResponse> CreateOrderDetail(CreateOrderDetailRequest createOrderDetailRequest);
        //Task<IPaginate<GetOrderDetailResponse>> GetOrderDetailsByCustomerId(string id, int page, int size);
        Task<bool> UpdateOrderDetail(string orderDetailId, UpdateOrderDetailRequest updateOrderDetailRequest);
    }
}