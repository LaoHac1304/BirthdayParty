﻿using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.OrderDetails;
using BirthdayParty.Domain.Payload.Response.OrderDetails;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BirthdayParty.Application.Service
{
    public interface IOrderDetailsService
    {
        Task<IPaginate<GetOrderDetailResponse>> GetOrderDetails(int page, int size);

        Task<GetOrderDetailResponse> GetOrderDetailById(string id);

        Task<bool> UpdatedOrderDetailById(string id);

        Task<GetOrderDetailResponse> CreateOrderDetail(CreateOrderDetailRequest createOrderDetailRequest);
        Task<IPaginate<GetOrderDetailResponse>> GetOrderDetailsByCustomerId(string id, int page, int size);
    }
}