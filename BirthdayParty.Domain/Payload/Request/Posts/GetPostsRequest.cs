using System.ComponentModel.DataAnnotations;

namespace BirthdayParty.Domain.Payload.Request.Posts;

public class GetPostsRequest
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}