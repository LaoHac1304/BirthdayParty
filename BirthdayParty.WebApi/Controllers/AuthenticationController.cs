using Microsoft.AspNetCore.Mvc;

namespace BirthdayParty.WebApi.Controllers
{
    [ApiController]
    public class AuthenticationController : BaseController<AuthenticationController>
    {
        public AuthenticationController(ILogger<AuthenticationController> logger) : base(logger)
        {
        }
    }
}
