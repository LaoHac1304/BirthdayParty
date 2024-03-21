using BirthdayParty.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayParty.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : BaseController<EmailController>
    {
        private readonly IEmailService _emailService;

        public EmailController(ILogger<EmailController> logger, IEmailService emailService) 
            : base(logger)
        {
            _emailService = emailService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {
            await _emailService.SendEmailAsync(request.OrderDetailId);
            return Ok();
        }
    }

    public class EmailRequest
    {
      public string OrderDetailId { get; set; }
    }
}
