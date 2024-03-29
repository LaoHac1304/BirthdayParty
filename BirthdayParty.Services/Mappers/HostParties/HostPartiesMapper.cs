﻿using AutoMapper;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Payload.Request.HostParties;
using BirthdayParty.Domain.Payload.Response.HostParties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Services.Mappers.HostParties
{
    public class HostPartiesMapper : Profile
    {
        public HostPartiesMapper() 
        {
            CreateMap<CreateHostPartyRequest, HostParty>();
            CreateMap<UpdateHostPartyRequest, HostParty>().IgnoreNull();
            CreateMap<HostParty, GetHostPartyResponse>();
        }
    }
}
