using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.OrderDetails;
using BirthdayParty.Domain.Payload.Response.OrderDetails;

namespace BirthdayParty.Application.Service
{
    public interface IOrderDetailsService
    {
        Task<IPaginate<GetOrderDetailResponse>> GetOrderDetails(GetOrderDetailsRequest request);

        Task<GetOrderDetailResponse> GetOrderDetailById(string id);

        Task<bool> UpdatedOrderDetailById(string id);

        Task<GetOrderDetailResponse> CreateOrderDetail(CreateOrderDetailRequest createOrderDetailRequest);
    }
}