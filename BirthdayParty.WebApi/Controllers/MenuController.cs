using BirthdayParty.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayParty.WebApi.Controllers;


[ApiController]
[Route("api/v1/menus")]
public class MenuController : BaseController<MenuController>
{
    public MenuController(ILogger<MenuController> logger) : base(logger)
    {
    }

    [HttpGet]
    public Task<ActionResult<IEnumerable<Menu>>> Get()
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("{id}")]
    public Task<ActionResult<Menu>> Get(string id)
    {
        throw new NotImplementedException();
    }
    
   [HttpPut("{id}")] 
    public Task<ActionResult<Menu>> Put(string id)
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete("{id}")]
    public Task<ActionResult<Menu>> Delete(string id)
    {
        throw new NotImplementedException();
    }
    
}