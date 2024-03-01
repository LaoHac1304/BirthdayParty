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
    public Task<ActionResult<PartyPackage>> Put(Guid id)
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Task<ActionResult<PartyPackage>> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
    
    
}