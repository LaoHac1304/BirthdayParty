using AutoMapper;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Payload.Request.Accounts;
using BirthdayParty.Domain.Payload.Response.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Services.Mappers.Accounts
{
    public class AccountMapper : Profile
    {
        public AccountMapper() {
            CreateMap<CreateAccountRequest, Account>();
            CreateMap<Account, CreateAccountResponse>();
            CreateMap<UpdateAccountRequest, Account>().IgnoreNull();
        }
    }
}
