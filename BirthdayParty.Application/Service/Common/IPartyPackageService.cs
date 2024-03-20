using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.PartyPackages;
using BirthdayParty.Domain.Payload.Request.Posts;
using BirthdayParty.Domain.Payload.Response.PartyPackages;
using BirthdayParty.Domain.Payload.Response.Posts;

namespace BirthdayParty.Application.Service.Common;

public interface IPartyPackageService
{
    public Task<string> CreatePost(string partyPackageId, CreatePostRequest request);
    public Task<IPaginate<GetPostsResponse>> GetPosts(string partyPackageId, GetPostsRequest request);
    Task<IPaginate<GetPartyPackageResponse>> GetPartyPackages(GetPartyPackagesRequest request);
    Task<string> CreatePartyPackage(CreatePartyPackageRequest request);
    Task<string> UpdatePartyPackage(string id, UpdatePartyPackageRequest request);
    Task<string> DeletePartyPackage(string id);
    Task<GetSinglePartyPackageResponse?> GetPartyPackage(string id);
}