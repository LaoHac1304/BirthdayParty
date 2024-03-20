using BirthdayParty.Application.Service.Common;
using BirthdayParty.Domain.Payload.Request.HostParties;
using BirthdayParty.WebApi.Constants;
using BirthdayParty.WebApi.Enums;
using BirthdayParty.WebApi.Validators;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayParty.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostPartyController : BaseController<HostPartyController>
    {
        private readonly IHostPartyService _hostPartyService;
        public HostPartyController(ILogger<HostPartyController> logger, IHostPartyService hostPartyService) : base(logger)
        {
            _hostPartyService = hostPartyService;
        }

        //[CustomAuthorize(RoleEnum.admin)]
        [HttpGet(ApiEndPointConstant.HostParty.HostPartiesEndpoint)]
        public async Task<IActionResult> GetHostParties([FromQuery] int page, [FromQuery] int size)
        {
            var hostParties = await _hostPartyService.GetHostParties(page, size);
            return Ok(hostParties);
        }

        [HttpGet(ApiEndPointConstant.HostParty.HostPartyEndpoint)]
        public async Task<IActionResult> GetHostParty(string id)
        {
            var hostParty = await _hostPartyService.GetHostPartyById(id);
            return Ok(hostParty);
        }
        [HttpPost(ApiEndPointConstant.HostParty.HostPartiesEndpoint)]
        public async Task<IActionResult> CreateHostParty([FromBody] CreateHostPartyRequest createHostPartyRequest)
        {
            var hostPartyId = await _hostPartyService.CreateHostParty(createHostPartyRequest);
            return Ok(hostPartyId);
        }

        [HttpPut(ApiEndPointConstant.HostParty.HostPartyEndpoint)]
        public async Task<IActionResult> UpdateHostParty(string id
            , [FromBody] UpdateHostPartyRequest updateHostPartyRequest)
        {
            bool isSuccessful = await _hostPartyService.UpdateHostPartyRequest(id, updateHostPartyRequest);
            if (isSuccessful)
            {
                return Ok("Update  successful !");
            }
            return Ok("Update Failed");
        }

        [HttpDelete(ApiEndPointConstant.HostParty.HostPartyEndpoint)]
        public async Task<IActionResult> DeleteHostParty(string id)
        {
            UpdateHostPartyRequest updateHostPartyRequest = new UpdateHostPartyRequest()
            {
                IsDeleted = true
            };
            bool isSuccessful = await _hostPartyService.UpdateHostPartyRequest(id, updateHostPartyRequest);
            if (isSuccessful)
            {
                return Ok("delete  successful !");
            }
            return Ok("delete Failed");
        }
    }
}
