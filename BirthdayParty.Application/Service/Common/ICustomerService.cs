using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.Customers;
using BirthdayParty.Domain.Payload.Response.Customers;
using BirthdayParty.Domain.Payload.Response.HostParties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Application.Service.Common
{
    public interface ICustomerService
    {
        Task<GetCustomerResponse> GetCustomerById(string id);
        Task<IPaginate<GetCustomerResponse>> GetCustomers(int page, int size);
        Task<bool> UpdateCustomerById(string id, UpdateCustomerRequest updateCustomerRequest);
        Task<GetCustomerResponse> GetCustomerByAccountId(string accountId);
    }
}
