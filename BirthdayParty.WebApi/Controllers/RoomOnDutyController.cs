using BirthdayParty.Application.Service.Common;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.RoomOnDutys;
using BirthdayParty.Domain.Payload.Request.Posts;
using BirthdayParty.Domain.Payload.Response.RoomOnDutys;
using BirthdayParty.Domain.Payload.Response.Posts;
using Microsoft.AspNetCore.Mvc;
using BirthdayParty.WebApi.Constants;

namespace BirthdayParty.WebApi.Controllers;

[ApiController]
[Route("api/v1/room-on-duty")]
public class RoomOnDutyController : BaseController<RoomOnDutyController>
{
    private readonly IRoomOnDutyService _roomOnDutyService;

    public RoomOnDutyController(ILogger<RoomOnDutyController> logger, IRoomOnDutyService roomOnDutyService) :
        base(logger)
    {
        _roomOnDutyService = roomOnDutyService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IPaginate<GetRoomOnDutysResponse>>> Get(
        [FromQuery] GetRoomOnDutysRequest request)
    {
        var result = await _roomOnDutyService.GetRoomOnDutys(request);
        return Ok(result);
    }

    [HttpPost(ApiEndPointConstant.RoomOnDuty.RoomOnDutyEndpoint)]
    public async Task<ActionResult<string>> Post([FromBody] CreateRoomOnDutyRequest request)
    {
        string result = await _roomOnDutyService.CreateRoomOnDuty(request);
        return Ok(result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<string>> Put([FromRoute] string id, [FromBody] UpdateRoomOnDutyRequest request)
    {
        string result = await _roomOnDutyService.UpdateRoomOnDuty(id, request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetSingleRoomOnDutyResponse>> Get([FromRoute] string id)
    {
        var result = await _roomOnDutyService.GetRoomOnDutyById(id);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RoomOnDuty>> Delete([FromRoute] string id)
    {
        string result = await _roomOnDutyService.DeleteRoomOnDuty(id);
        return Ok(result);
    }
}