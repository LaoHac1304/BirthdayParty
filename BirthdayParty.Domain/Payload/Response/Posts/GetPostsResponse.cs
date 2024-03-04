namespace BirthdayParty.Domain.Payload.Response.Posts;

public class GetPostsResponse
{
    public string Id { get; set; }

    public string? Content { get; set; }

    public DateTime? Date { get; set; }

    public string? ImageUrl { get; set; }

    public string? PartyPackageId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }
}