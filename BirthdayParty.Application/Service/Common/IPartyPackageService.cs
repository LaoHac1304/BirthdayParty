using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Payload.Request.Posts;

namespace BirthdayParty.Application.Service.Common;

public interface IPartyPackageService
{
    public Task<Post?> CreatePost(string partyPackageId, CreatePostRequest request);
}