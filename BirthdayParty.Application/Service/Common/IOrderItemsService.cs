using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.OrderItems;
using BirthdayParty.Domain.Payload.Response.OrderDetails;
using BirthdayParty.Domain.Payload.Response.OrderItems;

namespace BirthdayParty.Application.Service.Common
{
    public interface IOrderItemsService
    {
        Task<IPaginate<GetOrderItemsResponse>> GetOrderItems(int page, int size);

        Task<GetOrderItemsResponse> GetOrderItem(string id);

        Task<bool> UpdateOrderItem(string id, UpdateOrderItemsRequest updateOrderItemsRequest);

        Task<GetOrderItemsResponse> CreateOrderItem(CreateOrderItemsRequest createOrderItemsRequest);
    }
}