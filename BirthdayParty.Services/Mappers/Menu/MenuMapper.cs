using AutoMapper;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Payload.Request.Menus;
using BirthdayParty.Domain.Payload.Request.OrderDetails;
using BirthdayParty.Domain.Payload.Response.Menus;
using BirthdayParty.Domain.Payload.Response.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Services.Mappers.Menu
{
    public class MenuMapper : Profile
    {
        public MenuMapper()
        {
            CreateMap<CreateMenuRequest, BirthdayParty.Domain.Models.Menu>().ReverseMap();
            CreateMap<GetMenuResponse, BirthdayParty.Domain.Models.Menu>().ReverseMap();
        }
    }
}
