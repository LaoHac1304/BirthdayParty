using AutoMapper;
using BirthdayParty.Application.Repository.Common;
using BirthdayParty.Application.Service;
using BirthdayParty.Application.Service.Common;
using BirthdayParty.Domain.DbContexts;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Payload.Request.Accounts;
using BirthdayParty.Domain.Payload.Request.Authentications;
using BirthdayParty.Domain.Payload.Response;
using BirthdayParty.Domain.Payload.Response.Accounts;
using BirthdayParty.Services.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Services.Service
{
    public class AuthenticationService : BaseService<AuthenticationService>, IAuthenticationService
    {
        private readonly IAccountService _accountService;
        public AuthenticationService(IUnitOfWork unitOfWork, 
            ILogger<AuthenticationService> logger, IMapper mapper, 
            IHttpContextAccessor httpContextAccessor, IAccountService accountService) 
            : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
            _accountService = accountService;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            DecodedToken tokenData = GetInfoFromGoogleToken(loginRequest.TokenId);

            List<(string Type, string Value)> listClaims = tokenData.Claims;

            var email = listClaims.FirstOrDefault(claim => claim.Type == "email").Value;
            Tuple<string, Guid> guidClaim = null;

            //check exist email
            Account existAccount = await _unitOfWork.GetRepository<Account>().SingleOrDefaultAsync(
                predicate: x => x.Email.Equals(email));

            string jwtToken; 

            if (existAccount is null)
            {
                Account account = await CreateAccount(email, "customer");
                CreateCustomerResponse createCustomerResponse = await RegisterCustomer(account);
                account.Id = createCustomerResponse.Id;
                jwtToken = JwtUtil.GenerateJwtToken(account, guidClaim);

                return new LoginResponse
                {
                    Token = jwtToken,
                    Account = account,
                    RefreshToken = jwtToken
                };
            }   
            else
            {
                if (existAccount.IsDeleted == true) return null;
                jwtToken = JwtUtil.GenerateJwtToken(existAccount, guidClaim);
            }

            Console.WriteLine("Email: " + email);

            return new LoginResponse
            {
                Token = jwtToken,
                Account = existAccount,
                RefreshToken = jwtToken
            };
        }

        public async Task<Account> CreateAccount(string email, string role)
        {
            Account account = new Account()
            {
                Id = Guid.NewGuid().ToString(),
                Email = email,
                Role = role,
            };
            try
            {
                await _unitOfWork.GetRepository<Account>().InsertAsync(account);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            return account;
        }

        private async Task<CreateCustomerResponse> RegisterCustomer(Account account)
        {

            CreateCustomerRequest createCustomerRequest = new CreateCustomerRequest()
            {
                UserId = account.Id,
                FullName = account.Email.Split('@')[0],
            };


            CreateCustomerResponse createCustomerResponse = await _accountService
                                            .createCustomerAccount(createCustomerRequest);
            await _unitOfWork.CommitAsync();
            return createCustomerResponse;

        }

        public static DecodedToken GetInfoFromGoogleToken(string tokenId)
        {
            JwtSecurityToken token = JwtUtil.ConvertJwtStringToJwtSecurityToken(tokenId);
            DecodedToken tokenData = JwtUtil.DecodeJwt(token);
            return tokenData;
        }
    }
}
