using System.Net;
using BirthdayParty.Application.Service.Common;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.Posts;
using BirthdayParty.Domain.Payload.Response.Posts;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayParty.WebApi.Controllers;

[ApiController]
[Route("api/v1/posts")]
public class PostController : BaseController<PostController>
{
    private readonly IPostService _postService;

    public PostController(ILogger<PostController> logger, IPostService postService) : base(logger)
    {
        _postService = postService;
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Post>> Put([FromRoute] string id, [FromBody] UpdatePostRequest request)
    {
        string result = await _postService.UpdatePost(id, request);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<string>> Delete([FromRoute] string id)
    {
        var result = await _postService.RemovePost(id);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetSinglePostResponse>> Get([FromRoute] string id)
    {
        var result = await _postService.GetPost(id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IPaginate<GetPostsResponse>>> Get([FromQuery] GetPostsRequest request)
    {
        IPaginate<GetPostsResponse> result = await _postService.GetPosts(request);

        return Ok(result);
    }
}