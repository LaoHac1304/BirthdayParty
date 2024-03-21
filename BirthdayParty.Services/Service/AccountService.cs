using AutoMapper;
using BirthdayParty.Application.Repository.Common;
using BirthdayParty.Application.Service;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.Accounts;
using BirthdayParty.Domain.Payload.Request.Authentications;
using BirthdayParty.Domain.Payload.Response;
using BirthdayParty.Domain.Payload.Response.Accounts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BirthdayParty.Services.Service
{
    public class AccountService : BaseService<AccountService>, IAccountService
    {
        public AccountService(IUnitOfWork unitOfWork, 
            ILogger<AccountService> logger, IMapper mapper, 
            IHttpContextAccessor httpContextAccessor) 
            : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateAccountResponse> 
            createAccount(CreateAccountRequest createAccountRequest)
        {
            Account account = _mapper.Map<Account>(createAccountRequest);
            await _unitOfWork.GetRepository<Account>().InsertAsync(account);

            CreateAccountResponse createAccountResponse 
                = _mapper.Map<CreateAccountResponse>(account);
            return createAccountResponse;
        }

        public async Task<CreateCustomerResponse> 
            createCustomerAccount(CreateCustomerRequest createCustomerRequest)
        {
            Customer customer = _mapper.Map<Customer>(createCustomerRequest);

            customer.Id = Guid.NewGuid().ToString();

            await _unitOfWork.GetRepository<Customer>().InsertAsync(customer);

            CreateCustomerResponse createCustomerResponse 
                = _mapper.Map<CreateCustomerResponse>(customer);
            return createCustomerResponse;
        }

        public async Task<IPaginate<GetAccountResponse>> GetAccounts(int page, int size)
        {
            IPaginate<GetAccountResponse> accountsResponse
                = await _unitOfWork.GetRepository<Account>()
                .GetPagingListAsync(
                    selector: x => new GetAccountResponse(x.Id, x.Email, x.Role, x.CreatedAt, x.UpdatedAt, x.IsDeleted),
                    page: page,
                    size: size,
                    orderBy: x => x.OrderBy(x => x.CreatedAt));
            return accountsResponse;
        }

        public async Task<GetAccountResponse> GetAccountById(string id)
        {
            if (id == string.Empty) throw new BadHttpRequestException("Account Id is null or not exist");
            GetAccountResponse accountResponse = await _unitOfWork.GetRepository<Account>().SingleOrDefaultAsync(
                selector: x => new GetAccountResponse(x.Id, x.Email, x.Role, x.CreatedAt, x.UpdatedAt, x.IsDeleted),
                predicate: x => x.Id.Equals(id));
            return accountResponse;
        }

        public async Task<bool> UpdatedAccountById(string id, UpdateAccountRequest updateAccountRequest)
        {
            if (id == string.Empty) throw new BadHttpRequestException("Account Id is null or not exist");
            Account account = await _unitOfWork.GetRepository<Account>()
                .SingleOrDefaultAsync(
                predicate: x => x.Id.Equals(id));
            if (account == null) throw new BadHttpRequestException("Account was not found");
            _mapper.Map(updateAccountRequest, account); // map updatedRequest to account
            _unitOfWork.GetRepository<Account>().UpdateAsync(account);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            return isSuccessful;
        }
    }
}
