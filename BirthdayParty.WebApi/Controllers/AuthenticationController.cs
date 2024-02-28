using BirthdayParty.Application.Service.Common;
using BirthdayParty.Domain.Payload.Request.Authentications;
using BirthdayParty.WebApi.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayParty.WebApi.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : BaseController<AuthenticationController>
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(ILogger<AuthenticationController> logger
            , IAuthenticationService authenticationService) : base(logger)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost(ApiEndPointConstant.Authentication.Login)]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var loginResponse = await _authenticationService.Login(loginRequest);

            return Ok(loginResponse);

        }
    }
}
