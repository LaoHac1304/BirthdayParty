using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Payload.Request.Authentications;
using BirthdayParty.Domain.Payload.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Application.Service.Common
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task<Account> CreateAccount(string email, string role);
    }
}
