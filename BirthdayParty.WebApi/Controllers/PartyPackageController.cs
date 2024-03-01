using BirthdayParty.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayParty.WebApi.Controllers;


[ApiController]
[Route("api/v1/party-packages")]
public class PartyPackageController : BaseController<PartyPackageController>
{
    public PartyPackageController(ILogger<PartyPackageController> logger) : base(logger)
    {
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<ActionResult<IEnumerable<PartyPackage>>> Get()
    {
        throw new NotImplementedException();
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public Task<ActionResult<PartyPackage>> Post()
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Task<ActionResult<PartyPackage>> Put(string id)
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Task<ActionResult<PartyPackage>> Delete(string id)
    {
        throw new NotImplementedException();
    }

    [HttpPost("{partyPackageId}/posts")]
    public Task<ActionResult<Post>> CreatePost(string partyPackageId)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("{partyPackageId}/posts")]
    public Task<ActionResult<IEnumerable<Post>>> GetPosts(string partyPackageId)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost("{partyPackageId}/menus")]
    public Task<ActionResult<Menu>> CreateMenu(string partyPackageId)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("{partyPackageId}/menus")]
    public Task<ActionResult<Menu>> GetMenus(string partyPackageId)
    {
        throw new NotImplementedException();
    } 
    
}