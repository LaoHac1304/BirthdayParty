using AutoMapper;
using BirthdayParty.Application.Repository.Common;
using BirthdayParty.Application.Service.Common;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.Posts;
using BirthdayParty.Domain.Payload.Response.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BirthdayParty.Services.Service;

public class PostService : BaseService<PostService>, IPostService
{
    public PostService(IUnitOfWork unitOfWork, ILogger<PostService> logger, IMapper mapper,
        IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
    {
    }

    public Task<GetSinglePostResponse> GetPost(string id)
    {
        try
        {
            var result = _unitOfWork.GetRepository<Post>().SingleOrDefaultAsync<GetSinglePostResponse>(
                predicate: x => x.Id == id,
                selector: x => new GetSinglePostResponse
                {
                    Id = x.Id,
                    Content = x.Content,
                    Date = x.Date,
                    ImageUrl = x.ImageUrl,
                    PartyPackageId = x.PartyPackageId,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    IsDeleted = x.IsDeleted
                }
            );

            return result;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public Task<IPaginate<GetPostsResponse>> GetPosts(GetPostsRequest request)
    {
        try
        {
            var result = _unitOfWork.GetRepository<Post>().GetPagingListAsync<GetPostsResponse>(
                selector: post => new GetPostsResponse()
                {
                    Id = post.Id,
                    Content = post.Content,
                    Date = post.Date,
                    ImageUrl = post.ImageUrl,
                    PartyPackageId = post.PartyPackageId,
                    CreatedAt = post.CreatedAt,
                    UpdatedAt = post.UpdatedAt,
                    IsDeleted = post.IsDeleted
                },
                page: request.Page,
                size: request.PageSize
            );

            return result;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<string> UpdatePost(string id, UpdatePostRequest request)
    {
        try
        {
            var toBeUpdated = await _unitOfWork.GetRepository<Post>().SingleOrDefaultAsync(predicate: x => x.Id == id);

            if (toBeUpdated == null) return "Not found";

            toBeUpdated.Content = !string.IsNullOrEmpty(request.Content) ? request.Content : toBeUpdated.Content;
            toBeUpdated.ImageUrl = !string.IsNullOrEmpty(request.ImageUrl) ? request.ImageUrl : toBeUpdated.ImageUrl;
            toBeUpdated.Date = request.Date ?? toBeUpdated.Date;
            toBeUpdated.UpdatedAt = DateTime.Now;
            toBeUpdated.PartyPackageId = !string.IsNullOrEmpty(request.PartyPackageId)
                ? request.PartyPackageId
                : toBeUpdated.PartyPackageId;

            _unitOfWork.GetRepository<Post>().UpdateAsync(toBeUpdated);
            await _unitOfWork.CommitAsync();

            var message = "Updated Successfully";

            return message;
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public async Task<string> RemovePost(string id)
    {
        try
        {
            var toBeRemoved = await _unitOfWork.GetRepository<Post>().SingleOrDefaultAsync(predicate: x => x.Id == id);

            if (toBeRemoved == null) return "Not found";

            _unitOfWork.GetRepository<Post>().DeleteAsync(toBeRemoved);
            await _unitOfWork.CommitAsync();

            var message = "Deleted Successfully";

            return message;
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public async Task<string> CreatePost(CreatePostRequest request)
    {
        try
        {
            var toBeAdded = new Post()
            {
                Id = Guid.NewGuid().ToString(),
                IsDeleted = false,
                Content = request.Content,
                Date = DateTime.Now,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                ImageUrl = request.ImageUrl,
            };
            
            await _unitOfWork.GetRepository<Post>().InsertAsync(toBeAdded);
            await _unitOfWork.CommitAsync();
            
            var message = "Created Successfully";
            return message;
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }
}