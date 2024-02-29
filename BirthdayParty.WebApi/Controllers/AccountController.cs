using BirthdayParty.Application.Service;
using BirthdayParty.Domain.Payload.Request.Accounts;
using BirthdayParty.WebApi.Constants;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayParty.WebApi.Controllers
{
    [ApiController]
    public class AccountController : BaseController<AccountController>
    {
        private readonly IAccountService _accountService;
        public AccountController(ILogger<AccountController> logger, 
            IAccountService accountService) 
            : base(logger)
        {
            _accountService = accountService;
        }

        [HttpGet(ApiEndPointConstant.Account.AccountsEndpoint)]
        public async Task<IActionResult> GetAccounts([FromQuery] int page, [FromQuery] int size)
        {
            var accounts = await _accountService.GetAccounts(page, size);
            return Ok(accounts);
        }

        [HttpGet(ApiEndPointConstant.Account.AccountEndpoint)]
        public async Task<IActionResult> GetAccountById(string id)
        {
            var account = await _accountService.GetAccountById(id);
            return Ok(account);
        }

        [HttpPatch(ApiEndPointConstant.Account.AccountEndpoint)]
        public async Task<IActionResult> UpdateAccountById(string id, UpdateAccountRequest updateAccountRequest)
        {
            bool isSuccessful = await _accountService.UpdatedAccountById(id, updateAccountRequest);
            if (isSuccessful)
            {
                return Ok("Update account is successful !");
            }
            return Ok("Update Failed");
        }
    }
}
