using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.Posts;
using BirthdayParty.Domain.Payload.Response.Posts;

namespace BirthdayParty.Application.Service.Common;

public interface IPostService
{
    Task<GetSinglePostResponse> GetPost(string id);
    Task<IPaginate<GetPostsResponse>> GetPosts(GetPostsRequest request);
    Task<string> UpdatePost(string id, UpdatePostRequest request);
    Task<string> RemovePost(string id);
}