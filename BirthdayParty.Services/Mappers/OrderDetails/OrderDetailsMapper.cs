using AutoMapper;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Payload.Request.Accounts;
using BirthdayParty.Domain.Payload.Request.OrderDetails;
using BirthdayParty.Domain.Payload.Response.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Services.Mappers.OrderDetails
{
    public class OrderDetailsMapper : Profile
    {
        public OrderDetailsMapper()
        {
            CreateMap<CreateOrderDetailRequest, OrderDetail>().ReverseMap();
            CreateMap<GetOrderDetailResponse, OrderDetail>().ReverseMap();
        }
    }
}
