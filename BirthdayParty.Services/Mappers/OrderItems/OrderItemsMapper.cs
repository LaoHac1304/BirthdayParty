using AutoMapper;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Payload.Request.OrderItems;
using BirthdayParty.Domain.Payload.Response.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Services.Mappers.OrderItems
{
    public class OrderItemsMapper : Profile
    {
        public OrderItemsMapper()
        {
            CreateMap<GetOrderItemsResponse, OrderItem>().ReverseMap();
            CreateMap<CreateOrderItemsRequest, OrderItem>().ReverseMap();
            
        }
    }
}
