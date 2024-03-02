using AutoMapper;
using BirthdayParty.Application.Repository.Common;
using BirthdayParty.Application.Service.Common;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Payload.Request.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BirthdayParty.Services.Service;

public class PartyPackageService : BaseService<PartyPackageService>,IPartyPackageService
{
     public PartyPackageService(IUnitOfWork unitOfWork, ILogger<PartyPackageService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
        }
    public Task<Post?> CreatePost(string partyPackageId, CreatePostRequest request)
    {
        try
        {
            var toBeAdded = new Post
            {
                PartyPackageId = partyPackageId,
                Content = request.Content,
                Date = DateTime.Now
            };

            _unitOfWork.GetRepository<Post>().InsertAsync(toBeAdded);
            _unitOfWork.CommitAsync();

            return null;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

   
}