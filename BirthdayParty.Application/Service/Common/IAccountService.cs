using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.Accounts;
using BirthdayParty.Domain.Payload.Request.Authentications;
using BirthdayParty.Domain.Payload.Response;
using BirthdayParty.Domain.Payload.Response.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Application.Service
{
    public interface IAccountService
    {
        Task<CreateCustomerResponse> createCustomerAccount(CreateCustomerRequest createCustomerRequest);
        Task<GetAccountResponse> GetAccountById(string id);
        Task<IPaginate<GetAccountResponse>> GetAccounts(int page, int size);
        Task<bool> UpdatedAccountById(string id, UpdateAccountRequest updateAccountRequest);
    }
}
