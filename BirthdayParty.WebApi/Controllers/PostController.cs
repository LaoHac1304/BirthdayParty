using System.Net;
using BirthdayParty.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayParty.WebApi.Controllers;


[ApiController]
[Route("api/v1/posts")]
public class PostController : BaseController<PostController>
{
    public PostController(ILogger<PostController> logger) : base(logger)
    {
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    
    public Task<ActionResult<Post>> Put(string id)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Task<ActionResult<Post>> Delete(string id)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public Task<ActionResult<Post>> Get(string id)
    {
        throw new NotImplementedException();
    }
}