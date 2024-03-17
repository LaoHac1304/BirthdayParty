using AutoMapper;
using BirthdayParty.Application.Repository.Common;
using BirthdayParty.Application.Service.Common;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.Customers;
using BirthdayParty.Domain.Payload.Request.HostParties;
using BirthdayParty.Domain.Payload.Response.Customers;
using BirthdayParty.Domain.Payload.Response.HostParties;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Services.Service
{
    public class CustomerService : BaseService<CustomerService>, ICustomerService
    {
        public CustomerService(IUnitOfWork unitOfWork
            , ILogger<CustomerService> logger
            , IMapper mapper
            , IHttpContextAccessor httpContextAccessor) 
            : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
        }

        public async Task<GetCustomerResponse> GetCustomerByAccountId(string accountId)
        {
            GetCustomerResponse CustomerResponse = await _unitOfWork
                .GetRepository<Customer>()
                .SingleOrDefaultAsync(
                    selector: x => new GetCustomerResponse(x.Id, x.FullName, x.DayOfBirth
                    , x.CreatedAt, x.UpdatedAt, x.IsDeleted, x.PhoneNumber, x.User!.Email, x.ImageUrl),
                    predicate: x => x.UserId.Equals(accountId)
                 );
            if (CustomerResponse == null) throw new BadHttpRequestException("customer is not found");
            return CustomerResponse;
        }

        public async Task<GetCustomerResponse> GetCustomerById(string id)
        {
            GetCustomerResponse CustomerResponse = await _unitOfWork
                .GetRepository<Customer>()
                .SingleOrDefaultAsync(
                    selector: x => new GetCustomerResponse(x.Id, x.FullName, x.DayOfBirth
                    , x.CreatedAt, x.UpdatedAt, x.IsDeleted, x.PhoneNumber, x.User!.Email, x.ImageUrl),
                    predicate: x => x.Id.Equals(id)
                 );
            if (CustomerResponse == null) throw new BadHttpRequestException("customer is not found");
            return CustomerResponse;
        }

        public async Task<IPaginate<GetCustomerResponse>> GetCustomers(int page, int size)
        {
            IPaginate<GetCustomerResponse> customersResponse
                = await _unitOfWork.GetRepository<Customer>()
                .GetPagingListAsync(
                    selector: x => new GetCustomerResponse(x.Id, x.FullName, x.DayOfBirth
                    , x.CreatedAt, x.UpdatedAt, x.IsDeleted, x.PhoneNumber, x.User!.Email, x.ImageUrl),
                    page: page,
                    size: size,
                    orderBy: x => x.OrderBy(x => x.CreatedAt));
            return customersResponse;
        }

        public async Task<bool> UpdateCustomerById(string id, UpdateCustomerRequest updateCustomerRequest)
        {
            if (id == string.Empty) throw new BadHttpRequestException("Customer Id is null or not exist");
            Customer Customer = await _unitOfWork
                .GetRepository<Customer>()
                .SingleOrDefaultAsync(predicate: x => x.Id.Equals(id));
            if (Customer == null) throw new BadHttpRequestException("customer is not found");
            Customer = _mapper.Map(updateCustomerRequest, Customer);
            _unitOfWork.GetRepository<Customer>().UpdateAsync(Customer);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            return isSuccessful;
        }
    }
}
