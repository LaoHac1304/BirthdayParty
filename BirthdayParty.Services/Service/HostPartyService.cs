using AutoMapper;
using BirthdayParty.Application.Repository.Common;
using BirthdayParty.Application.Service;
using BirthdayParty.Application.Service.Common;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.Accounts;
using BirthdayParty.Domain.Payload.Request.HostParties;
using BirthdayParty.Domain.Payload.Response.Accounts;
using BirthdayParty.Domain.Payload.Response.HostParties;
using BirthdayParty.Services.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Services.Service
{
    public class HostPartyService : BaseService<AccountService>, IHostPartyService
    {
        private readonly IAccountService _accountService;
        private readonly IAuthenticationService _authenticationService;
        public HostPartyService(IUnitOfWork unitOfWork, ILogger<AccountService> logger
            , IMapper mapper, IHttpContextAccessor httpContextAccessor
            , IAccountService accountService, IAuthenticationService authenticationService)
            : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
            _accountService = accountService;
            _authenticationService = authenticationService;
        }

        public async Task<string> CreateHostParty(CreateHostPartyRequest createHostPartyRequest)
        {
            //create account 
            //check exist email
            Account existAccount = await _unitOfWork.GetRepository<Account>().SingleOrDefaultAsync(
                predicate: x => x.Email.Equals(createHostPartyRequest.Email));

            if (existAccount is null)
            {
                Account account = await _authenticationService.CreateAccount(createHostPartyRequest.Email, "host");
                string id = await RegisterHostParty(account, createHostPartyRequest);
                account.Id = id;
            }
            else
            {
                if (existAccount.IsDeleted == true) return null;
            }

            HostParty hostParty = _mapper.Map<HostParty>(createHostPartyRequest);
            return hostParty.Id;
        }

        private async Task<string>
            RegisterHostParty(Account account, CreateHostPartyRequest createHostPartyRequest)
        {
            CreateAccountRequest createAccountRequest
                = new CreateAccountRequest()
                {
                    Email = account.Email,
                    FullName = account.Email.Split('@')[0],

                };
            CreateAccountResponse createAccountResponse = await _accountService.createAccount(createAccountRequest);

            HostParty hostParty = new HostParty()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = createAccountResponse.Id,
                Description = createHostPartyRequest.Description
            };
            await _unitOfWork.GetRepository<HostParty>().InsertAsync(hostParty);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            if (isSuccessful == false) { return null; }
            return hostParty.Id;
        }

        public async Task<IPaginate<GetHostPartyResponse>> GetHostParties(int page, int size)
        {
            IPaginate<GetHostPartyResponse> accountsResponse
                = await _unitOfWork.GetRepository<HostParty>()
                .GetPagingListAsync(
                    selector: x => new GetHostPartyResponse(x.Id, x.Description, x.Rating
                    , x.CreatedAt, x.UpdatedAt, x.IsDeleted, x.PhoneNumber),
                    page: page,
                    size: size,
                    orderBy: x => x.OrderBy(x => x.CreatedAt));
            return accountsResponse;
        }

        public async Task<bool> UpdateHostPartyRequest(string id, UpdateHostPartyRequest updateHostPartyRequest)
        {
            if (id == string.Empty) throw new BadHttpRequestException("HostParty Id is null or not exist");
            HostParty hostParty = await _unitOfWork
                .GetRepository<HostParty>()
                .SingleOrDefaultAsync(predicate: x => x.Id.Equals(id));
            if (hostParty == null) throw new BadHttpRequestException("host party is not found");
            hostParty = _mapper.Map<HostParty>(updateHostPartyRequest);
            _unitOfWork.GetRepository<HostParty>().UpdateAsync(hostParty);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            return isSuccessful;
        }


        public async Task<GetHostPartyResponse> GetHostPartyById(string id)
        {
            GetHostPartyResponse hostPartyResponse = await _unitOfWork
                .GetRepository<HostParty>()
                .SingleOrDefaultAsync(
                    selector: x => new GetHostPartyResponse(x.Id, x.Description, x.Rating
                        , x.CreatedAt, x.UpdatedAt, x.IsDeleted, x.PhoneNumber),
                    predicate: x => x.Id.Equals(id)
                 );
            if (hostPartyResponse == null) throw new BadHttpRequestException("host party is not found");
            return hostPartyResponse;
        }

    }
}
