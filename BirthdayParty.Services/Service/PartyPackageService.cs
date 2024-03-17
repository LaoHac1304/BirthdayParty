using AutoMapper;
using BirthdayParty.Application.Repository.Common;
using BirthdayParty.Application.Service.Common;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.PartyPackages;
using BirthdayParty.Domain.Payload.Request.Posts;
using BirthdayParty.Domain.Payload.Response.HostParties;
using BirthdayParty.Domain.Payload.Response.PartyPackages;
using BirthdayParty.Domain.Payload.Response.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BirthdayParty.Services.Service;

public class PartyPackageService : BaseService<PartyPackageService>, IPartyPackageService
{
    private readonly IPostService _postService;
    public PartyPackageService(IUnitOfWork unitOfWork, ILogger<PartyPackageService> logger, IMapper mapper,
        IPostService postService,
        IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
    {
        _postService = postService;
    }

    public async Task<string> CreatePost(string partyPackageId, CreatePostRequest request)
    {
        try
        {

            return await _postService.CreatePost(request);
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public Task<IPaginate<GetPostsResponse>> GetPosts(string partyPackageId, GetPostsRequest request)
    {
        try
        {
            var result = _unitOfWork.GetRepository<Post>().GetPagingListAsync<GetPostsResponse>(
                predicate: x => x.PartyPackageId == partyPackageId, orderBy: x => x.OrderBy(x => x.CreatedAt),
                include: null, page: request.Page, size: request.PageSize, selector: x => new GetPostsResponse
                {
                    Id = x.Id,
                    Content = x.Content,
                    Date = x.Date,
                    ImageUrl = x.ImageUrl,
                    PartyPackageId = x.PartyPackageId,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    IsDeleted = x.IsDeleted
                });
            return result;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public Task<IPaginate<GetPartyPackagesResponse>> GetPartyPackages(GetPartyPackagesRequest request)
    {
        try
        {
            var result = _unitOfWork.GetRepository<PartyPackage>().GetPagingListAsync<GetPartyPackagesResponse>(
                selector: x => new GetPartyPackagesResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    Location = x.Location,
                    Price = x.Price,
                    HostPartyId = x.HostPartyId,
                    DiscountPercent = x.Discount!.DiscountPercent,
                    DiscountStatus = x.Discount!.Status,
                    Status = x.Status,
                    AvailableDates = x.AvailableDates,
                    ImageUrl = x.ImageUrl,
                    IsDeleted = x.IsDeleted,
                    AvailableForPreorder = x.AvailableForPreorder
                },
                predicate: null!,
                orderBy: x => x.OrderBy(partyPackage => partyPackage.CreatedAt),
                include: x => x.Include(partyPackage => partyPackage.Discount)!,
                page: request.Page,
                size: request.Size);


            return result;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<string> CreatePartyPackage(CreatePartyPackageRequest request)
    {
        try
        {
            var toBeAdded = new PartyPackage()
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Description = request.Description,
                Location = request.Location,
                Price = request.Price,
                HostPartyId = request.HostPartyId,
                AvailableDates = request.AvailableDates,
                ImageUrl = request.ImageUrl,
                DiscountId = request.DiscountId,
                AvailableForPreorder = request.AvailableForPreorder,
                Status = request.Status,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _unitOfWork.GetRepository<PartyPackage>().InsertAsync(toBeAdded);
            await _unitOfWork.CommitAsync();

            var message = "Created Successfully";
            return message;
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public async Task<string> UpdatePartyPackage(string id, UpdatePartyPackageRequest request)
    {
        try
        {
            var toBeUpdated = await _unitOfWork.GetRepository<PartyPackage>()
                .SingleOrDefaultAsync(predicate: x => x.Id == id);

            if (toBeUpdated == null) return "Not found";

            toBeUpdated.Name = !string.IsNullOrEmpty(request.Name) ? request.Name : toBeUpdated.Name;
            toBeUpdated.Description = !string.IsNullOrEmpty(request.Description)
                ? request.Description
                : toBeUpdated.Description;
            toBeUpdated.Location = !string.IsNullOrEmpty(request.Location) ? request.Location : toBeUpdated.Location;
            toBeUpdated.Price = request.Price ?? toBeUpdated.Price;
            toBeUpdated.HostPartyId = !string.IsNullOrEmpty(request.HostPartyId)
                ? request.HostPartyId
                : toBeUpdated.HostPartyId;
            toBeUpdated.AvailableDates = request.AvailableDates ?? toBeUpdated.AvailableDates;
            toBeUpdated.DiscountId = request.DiscountId;
            toBeUpdated.ImageUrl = !string.IsNullOrEmpty(request.ImageUrl) ? request.ImageUrl : toBeUpdated.ImageUrl;
            toBeUpdated.AvailableForPreorder = request.AvailableForPreorder ?? toBeUpdated.AvailableForPreorder;

            toBeUpdated.UpdatedAt = DateTime.Now;

            _unitOfWork.GetRepository<PartyPackage>().UpdateAsync(toBeUpdated);
            await _unitOfWork.CommitAsync();

            var message = "Updated Successfully";
            return message;
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public async Task<string> DeletePartyPackage(string id)
    {
        try
        {
            var toBeDeleted = await _unitOfWork.GetRepository<PartyPackage>()
                .SingleOrDefaultAsync(predicate: x => x.Id == id);
            
            if (toBeDeleted == null) return "Not found";
            
            _unitOfWork.GetRepository<PartyPackage>().DeleteAsync(toBeDeleted);
            await _unitOfWork.CommitAsync();

            var message = "Deleted Successfully";
            return message;
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public Task<GetSinglePartyPackageResponse?> GetPartyPackage(string id)
    {
        try
        {
            var result = _unitOfWork.GetRepository<PartyPackage>().SingleOrDefaultAsync<GetSinglePartyPackageResponse>(
                predicate: x => x.Id == id, selector: x => new GetSinglePartyPackageResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Location = x.Location,
                    Price = x.Price,
                    HostPartyId = x.HostPartyId,
                    DiscountPercent = x.Discount!.DiscountPercent,
                    DiscountStatus = x.Discount!.Status,
                    Status = x.Status,
                    AvailableDates = x.AvailableDates,
                    ImageUrl = x.ImageUrl,
                    IsDeleted = x.IsDeleted,
                    AvailableForPreorder = x.AvailableForPreorder,
                    HostParty = _mapper.Map<GetHostPartyResponse>(x.HostParty),
                });
            
            return result;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}