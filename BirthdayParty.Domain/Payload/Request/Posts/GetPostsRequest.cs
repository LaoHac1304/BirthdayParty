using System.ComponentModel.DataAnnotations;

namespace BirthdayParty.Domain.Payload.Request.Posts;

public class GetPostsRequest
{
    [Range(0, int.MaxValue, ErrorMessage = "Page must be greater than or equal to 0")]
    public int Page { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "PageSize must be greater than or equal to 0")]
    public int PageSize { get; set; }
}