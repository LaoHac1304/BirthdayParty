using System.ComponentModel.DataAnnotations;

namespace BirthdayParty.Domain.Payload.Request.Posts;

public class GetPostsRequest
{
    [Range(1, int.MaxValue)]
    [Required]
    public int Page { get; set; }
    [Range(1, int.MaxValue)]
    [Required]
    public int PageSize { get; set; }
}