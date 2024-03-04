using AutoMapper;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Payload.Request.Discounts;
using BirthdayParty.Domain.Payload.Response.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Services.Mappers.Discount
{
    public class DiscountMapper : Profile
    {
        public DiscountMapper()
        {
            CreateMap<CreateDiscountRequest, BirthdayParty.Domain.Models.Discount>().ReverseMap();
            CreateMap<GetDiscountResponse, BirthdayParty.Domain.Models.Discount>().ReverseMap();
        }
    }
}
