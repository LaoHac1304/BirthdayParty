using BirthdayParty.Application.Service.Common;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.PartyPackages;
using BirthdayParty.Domain.Payload.Request.Posts;
using BirthdayParty.Domain.Payload.Response.PartyPackages;
using BirthdayParty.Domain.Payload.Response.Posts;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayParty.WebApi.Controllers;

[ApiController]
[Route("api/v1/party-packages")]
public class PartyPackageController : BaseController<PartyPackageController>
{
    private readonly IPartyPackageService _partyPackageService;

    public PartyPackageController(ILogger<PartyPackageController> logger, IPartyPackageService partyPackageService) :
        base(logger)
    {
        _partyPackageService = partyPackageService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IPaginate<GetPartyPackagesResponse>>> Get(
        [FromQuery] GetPartyPackagesRequest request)
    {
        var result = await _partyPackageService.GetPartyPackages(request);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<string>> Post([FromBody] CreatePartyPackageRequest request)
    {
        string result = await _partyPackageService.CreatePartyPackage(request);
        return Ok(result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<string>> Put([FromRoute] string id, [FromBody] UpdatePartyPackageRequest request)
    {
        string result = await _partyPackageService.UpdatePartyPackage(id, request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetSinglePartyPackageResponse>> Get([FromRoute] string id)
    {
        var result = await _partyPackageService.GetPartyPackage(id);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PartyPackage>> Delete([FromRoute] string id)
    {
        string result = await _partyPackageService.DeletePartyPackage(id);
        return Ok(result);
    }

    // [HttpPost("{partyPackageId}/posts")]
    // public async Task<ActionResult<string>> CreatePost([FromRoute] string partyPackageId, CreatePostRequest request)
    // {
    //     var result = await _partyPackageService.CreatePost(partyPackageId, request);
    //     return Ok(result);
    // }
    //
    // [HttpGet("{partyPackageId}/posts")]
    // public async Task<ActionResult<IPaginate<GetPostsResponse>>> GetPosts([FromRoute] string partyPackageId,
    //     [FromQuery] GetPostsRequest request)
    // {
    //     var result = await _partyPackageService.GetPosts(partyPackageId, request);
    //     return Ok(result);
    // }
    //
    // [HttpPost("{partyPackageId}/menus")]
    // public Task<ActionResult<Menu>> CreateMenu(string partyPackageId)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // [HttpGet("{partyPackageId}/menus")]
    // public Task<ActionResult<Menu>> GetMenus(string partyPackageId)
    // {
    //     throw new NotImplementedException();
    // }
}